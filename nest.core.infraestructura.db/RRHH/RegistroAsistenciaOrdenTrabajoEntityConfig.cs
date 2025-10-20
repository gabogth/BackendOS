using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class RegistroAsistenciaOrdenTrabajoEntityConfig : IEntityTypeConfiguration<RegistroAsistenciaOrdenTrabajo>
    {
        public void Configure(EntityTypeBuilder<RegistroAsistenciaOrdenTrabajo> builder)
        {
            builder.ToTable("registro_asistencia_orden_trabajo", "rrhh");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.Property(x => x.Id)
                .ValueGeneratedNever();
            builder.HasOne(x => x.OrdenTrabajoCabecera)
                .WithMany()
                .HasForeignKey(x => x.OrdenTrabajoCabeceraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.RegistroAsistencia)
                .WithOne(c => c.RegistroAsistenciaOrdenTrabajo)
                .HasForeignKey<RegistroAsistenciaOrdenTrabajo>(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
