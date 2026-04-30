using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.Dto;
using nest.core.dominio.Security.Repositorios;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.security.Security
{
    public class IdentityRoleClaimRepository : IIdentityRoleClaimRepository
    {
        private readonly NestDbContext context;
        public IdentityRoleClaimRepository(NestDbContext context)
        {
            this.context = context;
        }

        public async Task AgregarRange(List<IdentityRoleClaim<string>> entries)
        {
            await context.RoleClaims.AddRangeAsync(entries);
            await context.SaveChangesAsync();
        }
        public async Task EliminarPorRolId(string roleId)
        {
            List<IdentityRoleClaim<string>> entries = await context.RoleClaims.Where(x => x.RoleId == roleId).ToListAsync();
            context.RoleClaims.RemoveRange(entries);
            await context.SaveChangesAsync();
        }
        public async Task MergeRange(string roleId, IReadOnlyCollection<ClaimDto> entries)
        {
            List<IdentityRoleClaim<string>> newEntries = entries.Select(x => new IdentityRoleClaim<string>() { ClaimType = x.Type, ClaimValue = x.Value, RoleId = roleId }).ToList();
            List<IdentityRoleClaim<string>> deletedEntries = await context.RoleClaims.Where(x => x.RoleId == roleId).ToListAsync();
            context.RoleClaims.RemoveRange(deletedEntries);
            await context.RoleClaims.AddRangeAsync(newEntries);
            await context.SaveChangesAsync();
        }
    }
}
