using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Usuarios.Queries;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Usuarios.Handlers
{
    public sealed class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, ApplicationUser?>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(UserManager<ApplicationUser> userManager, ILogger<ObtenerPorIdHandler> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
        }

        public async Task<ApplicationUser?> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await userManager.FindByIdAsync(request.UsuarioId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener el usuario {Id}", request.UsuarioId);
                throw;
            }
        }
    }
}
