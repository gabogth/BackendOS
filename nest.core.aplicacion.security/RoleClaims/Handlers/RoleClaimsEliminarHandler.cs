using System.Linq;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.RoleClaims.Commands;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.RoleClaims.Handlers;

public class RoleClaimsEliminarHandler : IRequestHandler<RoleClaimsEliminarCommand, Unit>
{
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly ILogger<RoleClaimsEliminarHandler> logger;

    public RoleClaimsEliminarHandler(RoleManager<ApplicationRole> roleManager, ILogger<RoleClaimsEliminarHandler> logger)
    {
        this.roleManager = roleManager;
        this.logger = logger;
    }

    public async Task<Unit> Handle(RoleClaimsEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ApplicationRole? role = await roleManager.FindByIdAsync(request.RoleId);
            if (role is null)
                throw new InvalidOperationException($"Rol {request.RoleId} no encontrado");

            IList<Claim> claims = await roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                IdentityResult result = await roleManager.RemoveClaimAsync(role, claim);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
            }

            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar los claims del rol {RoleId}", request.RoleId);
            throw;
        }
    }
}
