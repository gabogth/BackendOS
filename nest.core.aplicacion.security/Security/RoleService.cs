using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Security
{
    public class RoleService
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        public RoleService(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<List<ApplicationRole>> ObtenerTodos() => await this.roleManager.Roles.ToListAsync();
        public async Task<ApplicationRole> ObtenerPorId(string id) => await this.roleManager.FindByIdAsync(id);

        public async Task<ApplicationRole> Agregar(ApplicationRole role)
        {
            IdentityResult result = await this.roleManager.CreateAsync(role);
            if (result.Succeeded)
                return await this.roleManager.FindByNameAsync(role.Name);
            else throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
        }

        public async Task<ApplicationRole> Modificar(ApplicationRole role)
        {
            IdentityResult result = await this.roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return await this.roleManager.FindByNameAsync(role.Name);
            else throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
        }

        public async Task<bool> Eliminar(ApplicationRole role)
        {
            IdentityResult result = await this.roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return true;
            else throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
        }
    }
}
