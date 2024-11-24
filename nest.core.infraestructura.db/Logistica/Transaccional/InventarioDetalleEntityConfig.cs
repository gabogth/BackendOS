using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica.Transaccional;

namespace nest.core.infraestructura.db.Logistica.Transaccional
{
    public class InventarioDetalleEntityConfig : IEntityTypeConfiguration<InventarioDetalle>
    {
        public void Configure(EntityTypeBuilder<InventarioDetalle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("inventariodetalle", "logistica");
            builder.Property(x => x.Nota)
                .HasMaxLength(400);
            builder.HasOne(ic => ic.Producto)
                .WithMany()
                .HasForeignKey(ic => ic.ProductoId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ic => ic.ProductoLote)
                .WithMany()
                .HasForeignKey(ic => ic.ProductoLoteId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(d => d.InventarioCabecera)
                .WithMany(c => c.InventarioDetalles)
                .HasForeignKey(d => d.InventarioCabeceraId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
