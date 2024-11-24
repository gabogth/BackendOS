using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.Auth;

namespace nest.core.infraestructura.db.Security
{
    public class ApplicationRoleClaimEntityConfig : IEntityTypeConfiguration<IdentityRoleClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
        {
            builder.HasData(ObtenerRoleClaimsIniciales());
        }

        private static List<IdentityRoleClaim<string>> ObtenerRoleClaimsIniciales()
        {
            List<IdentityRoleClaim<string>> lsClaims = new List<IdentityRoleClaim<string>>();
            int counter = 1;
            lsClaims.AddRange(FormPoliciesEnum.Policies.Select(x => new IdentityRoleClaim<string> { Id = counter++, RoleId = "1", ClaimType = x.Value, ClaimValue = "true" }));
            lsClaims.AddRange(FormPoliciesEnum.Policies.Select(x => new IdentityRoleClaim<string> { Id = counter++, RoleId = "2", ClaimType = x.Value, ClaimValue = "true" }));
            return lsClaims;
        }
    }
}
