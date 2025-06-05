using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.Logistica
{
    public class ProductoEntityConfig : IEntityTypeConfiguration<Producto>
    {
        public static readonly string SCHEMA = "logistica";
        public static readonly string TABLE = "producto";
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
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
        public override int Next(EntityEntry entry) => (int)GeneradorCorrelativo.GetValue(entry.Context, ProductoEntityConfig.SCHEMA, ProductoEntityConfig.TABLE);
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => (int)await GeneradorCorrelativo.GetValueAsync(entry.Context, ProductoEntityConfig.SCHEMA, ProductoEntityConfig.TABLE, cancellationToken);
    }
}
