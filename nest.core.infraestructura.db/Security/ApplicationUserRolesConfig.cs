using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace nest.core.infraestructura.db.Security
{
    public class ApplicationUserRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(ObtenerInformacionInicial());
        }

        private static List<IdentityUserRole<string>> ObtenerInformacionInicial()
        {
            return new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "2", RoleId = "2" }
            };
        }
    }
}
