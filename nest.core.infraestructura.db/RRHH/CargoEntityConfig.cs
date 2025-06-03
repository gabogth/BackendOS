using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.CargoEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.RRHH
{
    public class CargoEntityConfig : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("cargo", "rrhh");
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
        public override int Next(EntityEntry entry) => 
            (entry.Context.Set<Cargo>().Max(g => (int?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => 
            (await entry.Context.Set<Cargo>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
