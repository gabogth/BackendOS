using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.aplicacion.security.Security
{
    public class UsuarioService
    {
        private readonly UserManager<ApplicationUser> userManager;
        public UsuarioService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<List<ApplicationUser>> ObtenerTodos() => await this.userManager.Users.ToListAsync();
        public async Task<ApplicationUser> ObtenerPorId(string id) => await this.userManager.FindByIdAsync(id);
        public async Task<List<ApplicationUser>> ObtenerPorRol(string roleName) => (await userManager.GetUsersInRoleAsync(roleName)).ToList();

        public async Task<ApplicationUser> Agregar(ApplicationUser user, string password)
        {
            user.UserName = user.Email;
            user.NormalizedUserName = user.Email.ToUpper();
            user.NormalizedEmail = user.Email.ToUpper();
            IdentityResult result = await this.userManager.CreateAsync(user, password);
            if (result.Succeeded)
                return await this.userManager.FindByNameAsync(user.UserName);
            else throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
        }

        public async Task<ApplicationUser> Modificar(ApplicationUser user)
        {
            ApplicationUser usuario = await this.userManager.FindByIdAsync(user.Id);
            if (usuario == null)
                throw new RegistroNoEncontradoException<ApplicationUser>(user.Id);
            usuario.PhoneNumber = user.PhoneNumber;
            IdentityResult result = await this.userManager.UpdateAsync(usuario);
            if (result.Succeeded)
                return await this.userManager.FindByIdAsync(usuario.Id);
            else throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
        }

        public async Task<bool> Eliminar(ApplicationUser user)
        {
            IdentityResult result = await this.userManager.DeleteAsync(user);
            if (result.Succeeded)
                return true;
            else throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
        }
    }
}
