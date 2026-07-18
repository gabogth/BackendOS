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
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.Personal)
                .WithMany(x => x.RegistroAsistencias)
                .HasForeignKey(x => x.PersonalId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Latitud)
                .HasPrecision(9, 6);
            builder.Property(x => x.Longitud)
                .HasPrecision(9, 6);
            builder.HasOne(x => x.HorarioDetalleEvento)
                .WithMany()
                .HasForeignKey(x => x.HorarioDetalleEventoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.RegistroAsistenciaPolitica)
                .WithMany()
                .HasForeignKey(x => x.RegistroAsistenciaPoliticaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.TerminalBiometrico)
                .WithMany()
                .HasForeignKey(x => x.TerminalBiometricoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
