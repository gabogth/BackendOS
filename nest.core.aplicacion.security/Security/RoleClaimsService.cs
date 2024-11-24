using Microsoft.AspNetCore.Identity;
using nest.core.dominio.Security;
using System.Security.Claims;

namespace nest.core.aplicacion.security.Security
{
    public class RoleClaimsService
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        public RoleClaimsService(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<List<Claim>> ObtenerPorRoleId(string roleId) 
        {
            ApplicationRole role = await this.roleManager.FindByIdAsync(roleId);
            return (await this.roleManager.GetClaimsAsync(role)).ToList(); 
        }

        public async Task Merge(string roleId, List<Claim> claims)
        {
            ApplicationRole role = await this.roleManager.FindByIdAsync(roleId);
            await this.Eliminar(role);
            foreach (Claim claim in claims)
            {
                IdentityResult result = await this.roleManager.AddClaimAsync(role, claim);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
            }
        }

        public async Task Eliminar(ApplicationRole role)
        {
            IList<Claim> claims = await this.roleManager.GetClaimsAsync(role);
            foreach (Claim claim in claims)
            {
                IdentityResult result = await roleManager.RemoveClaimAsync(role, claim);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
            }
        }
    }
}
