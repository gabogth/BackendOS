using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;

namespace nest.core.infraestructura.db.Logistica
{
    public class ProductoLoteEntityConfig : IEntityTypeConfiguration<ProductoLote>
    {
        public void Configure(EntityTypeBuilder<ProductoLote> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("productolote", "logistica");
            builder.HasOne(ic => ic.Producto)
                .WithMany()
                .HasForeignKey(ic => ic.ProductoId);
        }
    }
}
