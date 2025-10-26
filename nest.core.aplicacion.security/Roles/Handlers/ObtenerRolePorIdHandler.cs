using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Roles.Queries;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Roles.Handlers;

public class ObtenerRolePorIdHandler : IRequestHandler<ObtenerRolePorIdQuery, ApplicationRole>
{
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly ILogger<ObtenerRolePorIdHandler> logger;

    public ObtenerRolePorIdHandler(RoleManager<ApplicationRole> roleManager, ILogger<ObtenerRolePorIdHandler> logger)
    {
        this.roleManager = roleManager;
        this.logger = logger;
    }

    public async Task<ApplicationRole> Handle(ObtenerRolePorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await roleManager.FindByIdAsync(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el rol {RoleId}", request.Id);
            throw;
        }
    }
}
