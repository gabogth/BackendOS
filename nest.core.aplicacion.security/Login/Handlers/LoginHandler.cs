using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Login.Commands;
using nest.core.aplicacion.security.Login.Queries;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;
using nest.core.dominio.Security.UsuarioEmpresa;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.aplicacion.security.Login.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, CustomAccessTokenResponse>
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IClaimsGenerator claimsGenerator;
    private readonly IConfiguration configuration;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IUsuarioEmpresaRepository usuarioEmpresaRepository;
    private readonly ISender sender;
    private readonly ILogger<LoginHandler> logger;

    public LoginHandler(
        SignInManager<ApplicationUser> signInManager,
        IClaimsGenerator claimsGenerator,
        IConfiguration configuration,
        UserManager<ApplicationUser> userManager,
        IUsuarioEmpresaRepository usuarioEmpresaRepository,
        ISender sender,
        ILogger<LoginHandler> logger)
    {
        this.signInManager = signInManager;
        this.claimsGenerator = claimsGenerator;
        this.configuration = configuration;
        this.userManager = userManager;
        this.usuarioEmpresaRepository = usuarioEmpresaRepository;
        this.sender = sender;
        this.logger = logger;
    }

    public async Task<CustomAccessTokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;
            var user = await sender.Send(new ObtenerUsuarioPorEmailQuery(request.Email), cancellationToken);

            if (user is null)
            {
                throw new LoginFailedUserNameException();
            }

            SignInResult result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                throw new LoginFailedPasswordException();
            }

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
            logger.LogError(ex, "Error al iniciar sesión para el usuario {Email}.", request.Email);
            throw;
        }
    }
}
