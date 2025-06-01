using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Logistica;

namespace nest.core.infraestructura.db.Logistica
{
    public class UnidadMedidaEntityConfig : IEntityTypeConfiguration<UnidadMedida>
    {
        public void Configure(EntityTypeBuilder<UnidadMedida> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("unidad_medida", "logistica");
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.Property(x => x.Prefix)
                .HasMaxLength(5);
        }
    }
}
