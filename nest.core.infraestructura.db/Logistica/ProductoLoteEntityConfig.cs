using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.Logistica
{
    public class ProductoLoteEntityConfig : IEntityTypeConfiguration<ProductoLote>
    {
        public static readonly string SCHEMA = "logistica";
        public static readonly string TABLE = "producto_lote";
        public void Configure(EntityTypeBuilder<ProductoLote> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
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
        public override long Next(EntityEntry entry) => GeneradorCorrelativo.GetValue(entry.Context, ProductoLoteEntityConfig.SCHEMA, ProductoLoteEntityConfig.TABLE);
        public override async ValueTask<long> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync(entry.Context, ProductoLoteEntityConfig.SCHEMA, ProductoLoteEntityConfig.TABLE, cancellationToken);
    }
}
