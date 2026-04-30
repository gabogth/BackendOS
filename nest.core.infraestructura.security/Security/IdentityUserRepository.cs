using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.Repositorios;
using nest.core.infraestructura.db.DbContext;
using System.Security.Claims;

namespace nest.core.infraestructura.security.Security
{
    public class IdentityUserRepository : IIdentityUserRepository
    {
        private readonly NestDbContext context;
        public IdentityUserRepository(NestDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Claim>> ObtenerClaims(string userId, CancellationToken cancellationToken)
        {
            var userClaimsQuery =
                context.UserClaims.IgnoreQueryFilters()
                .Where(uc => uc.UserId == userId)
                .Select(uc => new
                {
                    uc.ClaimType,
                    uc.ClaimValue
                });

            var roleClaimsQuery =
                from ur in context.UserRoles.IgnoreQueryFilters()
                join rc in context.RoleClaims.IgnoreQueryFilters()
                    on ur.RoleId equals rc.RoleId
                where ur.UserId == userId
                select new
                {
                    rc.ClaimType,
                    rc.ClaimValue
                };

            var claims = await userClaimsQuery
                .Concat(roleClaimsQuery)
                .ToListAsync(cancellationToken);

            return claims
                .Select(x => new Claim(x.ClaimType!, x.ClaimValue!))
                .ToList();
        }
    }
}
