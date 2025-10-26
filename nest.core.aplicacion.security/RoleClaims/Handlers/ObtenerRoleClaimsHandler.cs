using System.Linq;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.RoleClaims.Queries;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.RoleClaims.Handlers;

public class ObtenerRoleClaimsHandler : IRequestHandler<ObtenerRoleClaimsQuery, List<Claim>>
{
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly ILogger<ObtenerRoleClaimsHandler> logger;

    public ObtenerRoleClaimsHandler(RoleManager<ApplicationRole> roleManager, ILogger<ObtenerRoleClaimsHandler> logger)
    {
        this.roleManager = roleManager;
        this.logger = logger;
    }

    public async Task<List<Claim>> Handle(ObtenerRoleClaimsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ApplicationRole? role = await roleManager.FindByIdAsync(request.RoleId);
            if (role is null)
                throw new InvalidOperationException($"Rol {request.RoleId} no encontrado");

            return (await roleManager.GetClaimsAsync(role)).ToList();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los claims del rol {RoleId}", request.RoleId);
            throw;
        }
    }
}
