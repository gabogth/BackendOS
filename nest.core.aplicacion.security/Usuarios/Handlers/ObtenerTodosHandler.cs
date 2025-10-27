using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Usuarios.Queries;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Usuarios.Handlers
{
    public sealed class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<ApplicationUser>>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(UserManager<ApplicationUser> userManager, ILogger<ObtenerTodosHandler> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
        }

        public async Task<List<ApplicationUser>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await userManager.Users.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los usuarios");
                throw;
            }
        }
    }
}
