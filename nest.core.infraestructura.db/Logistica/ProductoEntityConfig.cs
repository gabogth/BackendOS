using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;

namespace nest.core.infraestructura.db.Logistica
{
    public class ProductoEntityConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("producto", "logistica");
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(25);
            builder.HasOne(ic => ic.UnidadMedidaCompra)
                .WithMany()
                .HasForeignKey(ic => ic.UnidadMedidaCompraId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ic => ic.UnidadMedidaConsumo)
                .WithMany()
                .HasForeignKey(ic => ic.UnidadMedidaConsumoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
