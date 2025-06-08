using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.CargoEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.infraestructura.db.DbContext;

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
                .HasValueGenerator<CargoValueGenerator>();
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
    public class CargoValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) => GeneradorCorrelativo.GetValue<int>(entry, object () => ((NestDbContext)entry.Context).Cargos.Max(x => x.Id));
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync<int>(entry, object () => ((NestDbContext)entry.Context).Cargos.Max(x => x.Id), cancellationToken);
    }
}
