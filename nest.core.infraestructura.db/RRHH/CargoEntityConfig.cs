using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH;

namespace nest.core.infraestructura.db.RRHH
{
    public class CargoEntityConfig : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("cargo", "rrhh");
            builder.HasKey(x => x.Id);
            builder.HasData(ObtenerInformacionInicial());
        }

        public List<Cargo> ObtenerInformacionInicial()
        {
            List<Cargo> roles = new List<Cargo>()
            {
                new Cargo { Id = 1, Nombre = "BACKEND SPECIALIST", Estado = true },
                new Cargo { Id = 2, Nombre = "TEACH LEAD", Estado = true },
                new Cargo { Id = 3, Nombre = "CONTADOR", Estado = true },
            };
            return roles;
        }
    }
}
