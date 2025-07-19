using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;

namespace nest.core.infraestructura.db.Mantto
{
    public class MantenimientoTipoEntityConfig : IEntityTypeConfiguration<MantenimientoTipo>
    {
        public void Configure(EntityTypeBuilder<MantenimientoTipo> builder)
        {
            builder.ToTable("mantenimiento_tipo", "mantto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<short>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
