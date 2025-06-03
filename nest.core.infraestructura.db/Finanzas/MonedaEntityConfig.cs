using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.Finanzas
{
    public class MonedaEntityConfig : IEntityTypeConfiguration<Moneda>
    {
        public void Configure(EntityTypeBuilder<Moneda> builder)
        {
            builder.ToTable("moneda", "finanzas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<MonedaValueGenerator>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.Property(x => x.Prefix)
                .HasMaxLength(3);
            builder.Property(x => x.Sufix)
                .HasMaxLength(9);
            builder.Property(x => x.Simbolo)
                .HasMaxLength(3);
            builder.HasData(GetData());
        }

        private List<Moneda> GetData()
        {
            return new List<Moneda>
            {
                new Moneda { Id = 1, Nombre = "SOLES", NombreCorto = "PEN", Simbolo = "S/", Prefix = "S/", Sufix = "soles" },
                new Moneda { Id = 2, Nombre = "DÓLARES", NombreCorto = "USD", Simbolo = "$", Prefix = "$", Sufix = "dólares" },
                new Moneda { Id = 3, Nombre = "EUROS", NombreCorto = "EUR", Simbolo = "€", Prefix = "€", Sufix = "euros" }
            };
        }
    }
    public class MonedaValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) =>
            (entry.Context.Set<Moneda>().Max(g => (int?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<Moneda>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
