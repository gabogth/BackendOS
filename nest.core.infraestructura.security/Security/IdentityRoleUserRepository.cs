using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.Repositorios;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.security.Security
{
    public class IdentityRoleUserRepository : IIdentityRoleUserRepository
    {
        private readonly NestDbContext context;
        public IdentityRoleUserRepository(NestDbContext context)
        {
            this.context = context;
        }

        public async Task AgregarRange(List<IdentityUserRole<string>> entries)
        {
            await context.UserRoles.AddRangeAsync(entries);
            await context.SaveChangesAsync();
        }
        public async Task EliminarPorRolId(string roleId)
        {
            List<IdentityUserRole<string>> entries = await context.UserRoles.Where(x => x.RoleId == roleId).ToListAsync();
            context.UserRoles.RemoveRange(entries);
            await context.SaveChangesAsync();
        }
        public async Task MergeRange(string roleId, IReadOnlyCollection<string> usersId)
        {
            List<IdentityUserRole<string>> newEntries = usersId.Select(x => new IdentityUserRole<string>() { UserId = x, RoleId = roleId }).ToList();
            List<IdentityUserRole<string>> deletedEntries = await context.UserRoles.Where(x => x.RoleId == roleId).ToListAsync();
            context.UserRoles.RemoveRange(deletedEntries);
            await context.UserRoles.AddRangeAsync(newEntries);
            await context.SaveChangesAsync();
        }
    }
}
