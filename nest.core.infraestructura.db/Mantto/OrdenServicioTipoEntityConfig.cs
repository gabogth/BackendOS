using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.infraestructura.db.Mantto
{
    public class OrdenServicioTipoEntityConfig : IEntityTypeConfiguration<OrdenServicioTipo>
    {
        public void Configure(EntityTypeBuilder<OrdenServicioTipo> builder)
        {
            builder.ToTable("orden_servicio_tipo", "mantto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<short>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
