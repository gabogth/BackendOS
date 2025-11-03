using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Usuarios.Commands;
using nest.core.dominio.Security;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.aplicacion.security.Usuarios.Handlers
{
    public sealed class UsuarioModificarHandler : IRequestHandler<UsuarioModificarCommand, ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<UsuarioModificarHandler> logger;

        public UsuarioModificarHandler(UserManager<ApplicationUser> userManager, ILogger<UsuarioModificarHandler> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
        }

        public async Task<ApplicationUser> Handle(UsuarioModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await userManager.FindByIdAsync(request.Id)
                    ?? throw new RegistroNoEncontradoException<ApplicationUser>(request.Id);

                usuario.PhoneNumber = request.PhoneNumber;
                usuario.Email = request.Email;
                usuario.NormalizedEmail = request.Email?.ToUpperInvariant();
                usuario.UserName = request.Email;
                usuario.NormalizedUserName = request.Email?.ToUpperInvariant();

                IdentityResult result = await userManager.UpdateAsync(usuario);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
                }

                return await userManager.FindByIdAsync(usuario.Id)
                    ?? throw new RegistroNoEncontradoException<ApplicationUser>(usuario.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al modificar el usuario {Id}", request.Email);
                throw;
            }
        }
    }
}
