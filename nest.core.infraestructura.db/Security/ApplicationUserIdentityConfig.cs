using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security;

namespace nest.core.infraestructura.db.Security
{
    public class ApplicationUserIdentityConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(ObtenerInformacionInicial());
        }

        private static List<ApplicationUser> ObtenerInformacionInicial()
        {
            PasswordHasher<ApplicationUser> hash = new PasswordHasher<ApplicationUser>();
            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                new ApplicationUser { Id = "1", UserName = "admin@admin.com", NormalizedUserName = "ADMIN@ADMIN.COM", NormalizedEmail = "ADMIN@ADMIN.COM", Email = "admin@admin.com", EmailConfirmed = true },
                new ApplicationUser { Id = "2", UserName = "superadmin@admin.com", NormalizedUserName = "SUPERADMIN@ADMIN.COM", NormalizedEmail = "SUPERADMIN@ADMIN.COM", Email = "superadmin@admin.com", EmailConfirmed = true },
            };
            users[0].PasswordHash = hash.HashPassword(users[0], "admin");
            users[1].PasswordHash = hash.HashPassword(users[1], "superadmin");
            return users;
        }
    }
}
