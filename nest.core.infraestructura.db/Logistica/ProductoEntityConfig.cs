using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.Logistica
{
    public class ProductoEntityConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("producto", "logistica");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<ProductoValueGenerator>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(25);
            builder.HasOne(ic => ic.UnidadMedidaCompra)
                .WithMany()
                .HasForeignKey(ic => ic.UnidadMedidaCompraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ic => ic.UnidadMedidaConsumo)
                .WithMany()
                .HasForeignKey(ic => ic.UnidadMedidaConsumoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class ProductoValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) =>
            (entry.Context.Set<Producto>().Max(g => (int?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<Producto>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
