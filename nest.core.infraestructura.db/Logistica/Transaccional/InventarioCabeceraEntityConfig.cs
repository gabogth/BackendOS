using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Logistica.Transaccional;

namespace nest.core.infraestructura.db.Logistica.Transaccional
{
    public class InventarioCabeceraEntityConfig : IEntityTypeConfiguration<InventarioCabecera>
    {
        public void Configure(EntityTypeBuilder<InventarioCabecera> builder)
        {
            builder.ToTable("inventario_cabecera", "logistica");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<InventarioCabeceraValueGenerator>();
            builder.Property(x => x.Observacion)
                .HasMaxLength(-1);
            builder.HasOne(ic => ic.DocumentoTipo)
                .WithMany() 
                .HasForeignKey(ic => ic.DocumentoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ic => ic.LogisticaTransaccion)
                .WithMany()
                .HasForeignKey(ic => ic.LogisticaTransaccionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ic => ic.Almacen)
                .WithMany()
                .HasForeignKey(ic => ic.AlmacenId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class InventarioCabeceraValueGenerator : ValueGenerator<long>
    {
        public override bool GeneratesTemporaryValues => false;
        public override long Next(EntityEntry entry) =>
            (entry.Context.Set<InventarioCabecera>().Max(g => (long?)g.Id) ?? 0) + 1;
        public override async ValueTask<long> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<InventarioCabecera>().MaxAsync(g => (long?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
