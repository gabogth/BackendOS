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
                new ApplicationUser 
                {
                    Id = "1",
                    UserName = "admin@admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.COM",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEEeIExr86pRBXxafhFYbABge03ZqCG07elyWRluknySUeu0QYQn2AbIwIiLjMFraDQ==",
                    SecurityStamp = "6632853f-901c-4e10-b69e-2a5e3018b060",
                    ConcurrencyStamp = "86354a26-1cc5-4918-9d33-b049f317e4c6"
                },
                new ApplicationUser 
                {
                    Id = "2",
                    UserName = "superadmin@admin.com",
                    NormalizedUserName = "SUPERADMIN@ADMIN.COM",
                    NormalizedEmail = "SUPERADMIN@ADMIN.COM",
                    Email = "superadmin@admin.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEKk+GO+B1NIsiNc/9KsK7AcTcO2tYtYYVTAS3O053hE4W+ZIvEw1OF4GAhSMb1X/OA==",
                    SecurityStamp = "a25d6514-15b8-4c24-90cd-33de18fc4440",
                    ConcurrencyStamp = "c0c88fd7-3561-4fdc-a51a-10cd2bce8b2b"
                }
            };
            return users;
        }
    }
}
