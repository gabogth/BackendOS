using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class RegistroAsistenciaEntityConfig : IEntityTypeConfiguration<RegistroAsistencia>
    {
        public void Configure(EntityTypeBuilder<RegistroAsistencia> builder)
        {
            builder.ToTable("registro_asistencia", "rrhh");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.Property(x => x.Id)
                .ValueGeneratedNever();
            builder.HasOne(x => x.Personal)
                .WithMany()
                .HasForeignKey(x => x.PersonalId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.GrupoHorario)
                .WithMany()
                .HasForeignKey(x => x.GrupoHorarioId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.HorarioDetalle)
                .WithMany()
                .HasForeignKey(x => x.HorarioDetalleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
