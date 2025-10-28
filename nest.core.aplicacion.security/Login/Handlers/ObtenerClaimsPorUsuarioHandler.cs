using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using nest.core.aplicacion.security.Login.Queries;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;

namespace nest.core.aplicacion.security.Login.Handlers;

public class ObtenerClaimsPorUsuarioHandler : IRequestHandler<ObtenerClaimsPorUsuarioQuery, List<Claim>>
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<ApplicationRole> roleManager;

    public ObtenerClaimsPorUsuarioHandler(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public async Task<List<Claim>> Handle(ObtenerClaimsPorUsuarioQuery request, CancellationToken cancellationToken)
    {
        IList<string> roles = await userManager.GetRolesAsync(request.Usuario);
        var roleClaims = new List<Claim>();

        foreach (string roleName in roles)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role is null)
            {
                continue;
            }

            var claims = await roleManager.GetClaimsAsync(role);
            roleClaims.AddRange(claims);
        }

        return roleClaims;
    }
}
