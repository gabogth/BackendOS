using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security;
using System.Security.Claims;

namespace nest.core.aplicacion.security.Security
{
    public class RoleUsuarioService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        public RoleUsuarioService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task Merge(string roleName, List<string> usersId)
        {
            await this.Eliminar(roleName);
            List<ApplicationUser> usuarios = await this.userManager.Users.Where(x => usersId.Contains(x.Id)).ToListAsync();
            foreach (ApplicationUser user in usuarios)
            {
                IdentityResult result = await this.userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
            }
        }

        public async Task Eliminar(string roleName)
        {
            IList<ApplicationUser> users = await userManager.GetUsersInRoleAsync(roleName);
            foreach (ApplicationUser user in users)
            {
                IdentityResult result = await userManager.RemoveFromRoleAsync(user, roleName);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
            }
        }
    }
}
