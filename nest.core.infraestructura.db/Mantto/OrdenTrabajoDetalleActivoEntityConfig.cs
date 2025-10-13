using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.infraestructura.db.Mantto
{
    public class OrdenTrabajoDetalleActivoEntityConfig : IEntityTypeConfiguration<OrdenTrabajoDetalleActivo>
    {
        public void Configure(EntityTypeBuilder<OrdenTrabajoDetalleActivo> builder)
        {
            builder.ToTable("orden_trabajo_detalle_activo", "mantto");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
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
            builder.HasOne(p => p.OrdenTrabajoDetalle)
                .WithOne(c => c.OrdenTrabajoDetalleActivo)
                .HasForeignKey<OrdenTrabajoDetalleActivo>(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
