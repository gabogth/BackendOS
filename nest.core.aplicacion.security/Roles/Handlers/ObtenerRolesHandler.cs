using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Roles.Queries;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Roles.Handlers;

public class ObtenerRolesHandler : IRequestHandler<ObtenerRolesQuery, List<ApplicationRole>>
{
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly ILogger<ObtenerRolesHandler> logger;

    public ObtenerRolesHandler(RoleManager<ApplicationRole> roleManager, ILogger<ObtenerRolesHandler> logger)
    {
        this.roleManager = roleManager;
        this.logger = logger;
    }

    public async Task<List<ApplicationRole>> Handle(ObtenerRolesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await roleManager.Roles.ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los roles");
            throw;
        }
    }
}
