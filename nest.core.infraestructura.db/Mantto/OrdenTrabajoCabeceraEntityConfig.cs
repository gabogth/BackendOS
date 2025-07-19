using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.infraestructura.db.Mantto
{
    public class OrdenTrabajoCabeceraEntityConfig : IEntityTypeConfiguration<OrdenTrabajoCabecera>
    {
        public void Configure(EntityTypeBuilder<OrdenTrabajoCabecera> builder)
        {
            builder.ToTable("orden_trabajo_cabecera", "mantto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(d => d.OrdenServicioCabecera)
               .WithMany(c => c.OrdenTrabajoCabeceras)
               .HasForeignKey(d => d.OrdenServicioCabeceraId)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.OrdenTrabajoCabeceraPadre)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.OrdenTrabajoCabeceraPadreId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.GrupoTrabajo)
                .WithMany()
                .HasForeignKey(x => x.GrupoTrabajoId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
