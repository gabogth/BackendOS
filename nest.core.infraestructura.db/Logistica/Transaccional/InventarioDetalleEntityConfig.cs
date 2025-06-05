using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica.Transaccional;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.Logistica.Transaccional
{
    public class InventarioDetalleEntityConfig : IEntityTypeConfiguration<InventarioDetalle>
    {
        public static readonly string SCHEMA = "logistica";
        public static readonly string TABLE = "inventario_detalle";
        public void Configure(EntityTypeBuilder<InventarioDetalle> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<InventarioDetalleValueGenerator>();
            builder.Property(x => x.Nota)
                .HasMaxLength(400);
            builder.HasOne(ic => ic.Producto)
                .WithMany()
                .HasForeignKey(ic => ic.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ic => ic.ProductoLote)
                .WithMany()
                .HasForeignKey(ic => ic.ProductoLoteId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.InventarioCabecera)
                .WithMany(c => c.InventarioDetalles)
                .HasForeignKey(d => d.InventarioCabeceraId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class InventarioDetalleValueGenerator : ValueGenerator<long>
    {
        public override bool GeneratesTemporaryValues => false;
        public override long Next(EntityEntry entry) => GeneradorCorrelativo.GetValue(entry.Context, InventarioDetalleEntityConfig.SCHEMA, InventarioDetalleEntityConfig.TABLE);
        public override async ValueTask<long> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync(entry.Context, InventarioDetalleEntityConfig.SCHEMA, InventarioDetalleEntityConfig.TABLE, cancellationToken);
    }
}
