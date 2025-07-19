using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.infraestructura.db.Mantto
{
    public class OrdenTrabajoDetalleEntityConfig : IEntityTypeConfiguration<OrdenTrabajoDetalle>
    {
        public void Configure(EntityTypeBuilder<OrdenTrabajoDetalle> builder)
        {
            builder.ToTable("orden_trabajo_detalle", "mantto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.OrdenTrabajoCabecera)
                .WithMany()
                .HasForeignKey(x => x.OrdenTrabajoCabeceraId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.UbicacionTecnica)
                .WithMany()
                .HasForeignKey(x => x.UbicacionTecnicaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Labor)
                .WithMany()
                .HasForeignKey(x => x.LaborId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.OrdenTrabajoCabecera)
               .WithMany(c => c.OrdenTrabajoDetalles)
               .HasForeignKey(d => d.OrdenTrabajoCabeceraId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
