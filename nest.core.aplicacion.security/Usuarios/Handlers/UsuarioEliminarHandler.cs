using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Usuarios.Commands;
using nest.core.dominio.Security;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.aplicacion.security.Usuarios.Handlers
{
    public sealed class UsuarioEliminarHandler : IRequestHandler<UsuarioEliminarCommand, Unit>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<UsuarioEliminarHandler> logger;

        public UsuarioEliminarHandler(UserManager<ApplicationUser> userManager, ILogger<UsuarioEliminarHandler> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UsuarioEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await userManager.FindByIdAsync(request.UsuarioId)
                    ?? throw new RegistroNoEncontradoException<ApplicationUser>(request.UsuarioId);

                IdentityResult result = await userManager.DeleteAsync(usuario);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
                }

                return Unit.Value;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar el usuario {Id}", request.UsuarioId);
                throw;
            }
        }
    }
}
