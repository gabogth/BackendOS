using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.MonedaEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.infraestructura.db.DbContext;

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
                .HasValueGenerator<GenericValueGenerator<int>>();
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
        public override int Next(EntityEntry entry) => GeneradorCorrelativo.GetValue<int>(entry, object () => ((NestDbContext)entry.Context).Moneda.Max(x => x.Id));
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync<int>(entry, object () => ((NestDbContext)entry.Context).Moneda.Max(x => x.Id), cancellationToken);
    }
}
