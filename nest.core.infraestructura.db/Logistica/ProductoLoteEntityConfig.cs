using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.Logistica
{
    public class ProductoLoteEntityConfig : IEntityTypeConfiguration<ProductoLote>
    {
        public void Configure(EntityTypeBuilder<ProductoLote> builder)
        {
            builder.ToTable("producto_lote", "logistica");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<ProductoLoteValueGenerator>();
            builder.HasOne(ic => ic.Producto)
                .WithMany()
                .HasForeignKey(ic => ic.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class ProductoLoteValueGenerator : ValueGenerator<long>
    {
        public override bool GeneratesTemporaryValues => false;
        public override long Next(EntityEntry entry) =>
            (entry.Context.Set<ProductoLote>().Max(g => (long?)g.Id) ?? 0) + 1;
        public override async ValueTask<long> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<ProductoLote>().MaxAsync(g => (long?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
