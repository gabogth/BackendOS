using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;

namespace nest.core.infraestructura.db.Mantto
{
    public class OrdenServicioMantenimientoExternoEntityConfig : IEntityTypeConfiguration<OrdenServicioMantenimientoExterno>
    {
        public void Configure(EntityTypeBuilder<OrdenServicioMantenimientoExterno> builder)
        {
            builder.ToTable("orden_servicio_mantenimiento_externo", "mantto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ClienteSupervisor)
                .WithMany()
                .HasForeignKey(x => x.ClienteSupervisorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Contrato)
                .WithMany()
                .HasForeignKey(x => x.ContratoCabeceraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ClientePlanner)
                .WithMany()
                .HasForeignKey(x => x.ClientePlannerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ActaConformidad)
                .WithMany()
                .HasForeignKey(x => x.ActaConformidadId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Moneda)
                .WithMany()
                .HasForeignKey(x => x.MonedaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.MantenimientoTipo)
                .WithMany()
                .HasForeignKey(x => x.MantenimientoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.OrdenServicioCabecera)
                .WithMany()
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
