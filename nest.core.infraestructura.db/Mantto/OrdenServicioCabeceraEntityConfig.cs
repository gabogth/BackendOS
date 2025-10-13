using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;

namespace nest.core.infraestructura.db.Mantto
{
    public class OrdenServicioCabeceraEntityConfig : IEntityTypeConfiguration<OrdenServicioCabecera>
    {
        public void Configure(EntityTypeBuilder<OrdenServicioCabecera> builder)
        {
            builder.ToTable("orden_servicio_cabecera", "mantto");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.OrdenServicioTipo)
                .WithMany()
                .HasForeignKey(x => x.OrdenServicioTipoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.OrdenServicioMantenimientoExterno)
                .WithOne(p => p.OrdenServicioCabecera)
                .HasForeignKey<OrdenServicioMantenimientoExterno>(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
