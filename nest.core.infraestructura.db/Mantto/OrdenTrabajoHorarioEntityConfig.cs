using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.infraestructura.db.Mantto
{
    public class OrdenTrabajoHorarioEntityConfig : IEntityTypeConfiguration<OrdenTrabajoHorario>
    {
        public void Configure(EntityTypeBuilder<OrdenTrabajoHorario> builder)
        {
            builder.ToTable("orden_trabajo_horario", "mantto");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(d => d.OrdenTrabajoCabecera)
               .WithMany(c => c.OrdenTrabajoHorarios)
               .HasForeignKey(d => d.OrdenTrabajoCabeceraId)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.HorarioCabecera)
               .WithMany(c => c.OrdenTrabajoHorarios)
               .HasForeignKey(d => d.HorarioCabeceraId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Personal)
               .WithMany(c => c.OrdenTrabajoHorarios)
               .HasForeignKey(d => d.PersonalId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
