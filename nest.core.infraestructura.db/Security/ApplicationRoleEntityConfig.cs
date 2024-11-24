using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security;

namespace nest.core.infraestructura.db.Security
{
    public class ApplicationRoleEntityConfig : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(ObtenerInformacionInicial());
        }

        private static List<ApplicationRole> ObtenerInformacionInicial()
        {
            return new List<ApplicationRole>()
            {
                new ApplicationRole { Id = "1", Name = "admin", NormalizedName = "ADMIN" },
                new ApplicationRole { Id = "2", Name = "superadmin", NormalizedName = "SUPERADMIN" },
            };
        }
    }
}
