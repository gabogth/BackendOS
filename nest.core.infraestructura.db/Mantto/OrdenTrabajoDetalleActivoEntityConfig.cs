using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.infraestructura.db.Mantto
{
    public class OrdenTrabajoDetalleActivoEntityConfig : IEntityTypeConfiguration<OrdenTrabajoDetalleActivo>
    {
        public void Configure(EntityTypeBuilder<OrdenTrabajoDetalleActivo> builder)
        {
            builder.ToTable("orden_trabajo_detalle_activo", "mantto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.OrdenTrabajoDetalle)
                .WithMany()
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Activo)
                .WithMany()
                .HasForeignKey(x => x.ActivoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
