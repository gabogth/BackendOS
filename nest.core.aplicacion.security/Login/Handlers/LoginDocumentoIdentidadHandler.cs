using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Login.Commands;
using nest.core.aplicacion.security.Login.Queries;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;
using nest.core.dominio.Security.UsuarioEmpresa;
using nest.core.infrastructura.utils.Excepciones;
using System.Security.Claims;

namespace nest.core.aplicacion.security.Login.Handlers
{
    internal class LoginDocumentoIdentidadHandler : IRequestHandler<LoginDocumentoIdentidadCommand, CustomAccessTokenResponse>
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IClaimsGenerator claimsGenerator;
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsuarioEmpresaRepository usuarioEmpresaRepository;
        private readonly IPersonalRepository personalRepository;
        private readonly ISender sender;
        private readonly ILogger<LoginHandler> logger;

        public LoginDocumentoIdentidadHandler(
            SignInManager<ApplicationUser> signInManager,
            IClaimsGenerator claimsGenerator,
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IUsuarioEmpresaRepository usuarioEmpresaRepository,
            IPersonalRepository personalRepository,
            ISender sender,
            ILogger<LoginHandler> logger)
        {
            this.signInManager = signInManager;
            this.claimsGenerator = claimsGenerator;
            this.configuration = configuration;
            this.userManager = userManager;
            this.usuarioEmpresaRepository = usuarioEmpresaRepository;
            this.personalRepository = personalRepository;
            this.sender = sender;
            this.logger = logger;
        }

        public async Task<CustomAccessTokenResponse> Handle(LoginDocumentoIdentidadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;
                var personal = await personalRepository.ObtenerPorDocumentoIdentidad(request.tipoDocumentoId, request.documentoIdentidad);
                if(personal == null || string.IsNullOrWhiteSpace(personal.UsuarioId))
                    throw new Exception("No tienes asignado un usuario a tu codigo de personal");
                var user = await userManager.FindByIdAsync(personal.UsuarioId);
                if (user is null)
                    throw new LoginFailedUserNameException();

                List<Claim> claims = await sender.Send(new ObtenerClaimsPorUsuarioQuery(user), cancellationToken);
                UsuarioEmpresa? usuarioEmpresa = await usuarioEmpresaRepository.ObtenerSeleccionado(user.Id);

                CustomAccessTokenResponse response = claimsGenerator.build(
                    user,
                    claims,
                    usuarioEmpresa?.EmpresaId,
                    configuration["Jwt:Key"],
                    configuration["Jwt:Issuer"],
                    configuration["Jwt:Audience"]);

                var resultToken = await userManager.SetAuthenticationTokenAsync(user, "onPremises", "AccessToken", response.AccessToken);
                if (resultToken.Succeeded)
                {
                    await userManager.SetAuthenticationTokenAsync(user, "onPremises", "RefreshToken", response.RefreshToken);
                }

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error al iniciar sesión para el documento {request.tipoDocumentoId}-{request.documentoIdentidad}.");
                throw;
            }
        }
    }
}
