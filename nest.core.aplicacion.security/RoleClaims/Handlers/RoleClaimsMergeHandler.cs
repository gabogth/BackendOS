using System.Linq;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.RoleClaims.Commands;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.RoleClaims.Handlers;

public class RoleClaimsMergeHandler : IRequestHandler<RoleClaimsMergeCommand, Unit>
{
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly ILogger<RoleClaimsMergeHandler> logger;

    public RoleClaimsMergeHandler(RoleManager<ApplicationRole> roleManager, ILogger<RoleClaimsMergeHandler> logger)
    {
        this.roleManager = roleManager;
        this.logger = logger;
    }

    public async Task<Unit> Handle(RoleClaimsMergeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ApplicationRole? role = await roleManager.FindByIdAsync(request.RoleId);
            if (role is null)
                throw new InvalidOperationException($"Rol {request.RoleId} no encontrado");

            IList<Claim> currentClaims = await roleManager.GetClaimsAsync(role);
            foreach (var claim in currentClaims)
            {
                IdentityResult removeResult = await roleManager.RemoveClaimAsync(role, claim);
                if (!removeResult.Succeeded)
                    throw new Exception(string.Join(", ", removeResult.Errors.Select(p => p.Description)));
            }

            foreach (var claim in request.Claims)
            {
                IdentityResult addResult = await roleManager.AddClaimAsync(role, new Claim(claim.Type, claim.Value));
                if (!addResult.Succeeded)
                    throw new Exception(string.Join(", ", addResult.Errors.Select(p => p.Description)));
            }

            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al actualizar los claims del rol {RoleId}", request.RoleId);
            throw;
        }
    }
}
