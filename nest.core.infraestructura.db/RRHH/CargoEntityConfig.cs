using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class CargoEntityConfig : IEntityTypeConfiguration<Cargo>
    {
        public static readonly string SCHEMA = "rrhh";
        public static readonly string TABLE = "cargo";
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
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
