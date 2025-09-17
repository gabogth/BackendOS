using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;

namespace nest.core.infraestructura.db.Logistica
{
    public class ProductoLoteEntityConfig : IEntityTypeConfiguration<ProductoLote>
    {
        public void Configure(EntityTypeBuilder<ProductoLote> builder)
        {
            builder.ToTable("producto_lote", "logistica");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(ic => ic.Producto)
                .WithMany()
                .HasForeignKey(ic => ic.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
