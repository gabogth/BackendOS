using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;

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
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.Property(x => x.Prefix)
                .HasMaxLength(5);
        }
    }
}
