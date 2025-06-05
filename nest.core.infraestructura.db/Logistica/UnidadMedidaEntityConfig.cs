using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.Logistica
{
    public class UnidadMedidaEntityConfig : IEntityTypeConfiguration<UnidadMedida>
    {
        public static readonly string SCHEMA = "logistica";
        public static readonly string TABLE = "unidad_medida";
        public void Configure(EntityTypeBuilder<UnidadMedida> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<UnidadMedidaValueGenerator>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.Property(x => x.Prefix)
                .HasMaxLength(5);
        }
    }
    public class UnidadMedidaValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) => (int)GeneradorCorrelativo.GetValue(entry.Context, UnidadMedidaEntityConfig.SCHEMA, UnidadMedidaEntityConfig.TABLE);
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => (int)await GeneradorCorrelativo.GetValueAsync(entry.Context, UnidadMedidaEntityConfig.SCHEMA, UnidadMedidaEntityConfig.TABLE, cancellationToken);
    }
}
