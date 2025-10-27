using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Usuarios.Queries;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Usuarios.Handlers
{
    public sealed class ObtenerPorRolHandler : IRequestHandler<ObtenerPorRolQuery, List<ApplicationUser>>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<ObtenerPorRolHandler> logger;

        public ObtenerPorRolHandler(UserManager<ApplicationUser> userManager, ILogger<ObtenerPorRolHandler> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
        }

        public async Task<List<ApplicationUser>> Handle(ObtenerPorRolQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarios = await userManager.GetUsersInRoleAsync(request.RoleName);
                return usuarios.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener usuarios para el rol {Role}", request.RoleName);
                throw;
            }
        }
    }
}
