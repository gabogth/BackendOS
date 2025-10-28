using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class RegistroAsistenciaAdjuntoEntityConfig : IEntityTypeConfiguration<RegistroAsistenciaAdjunto>
    {
        public void Configure(EntityTypeBuilder<RegistroAsistenciaAdjunto> builder)
        {
            builder.ToTable("registro_asistencia_adjunto", "rrhh");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.RegistroAsistencia)
                .WithOne(x => x.RegistroAsistenciaAdjunto)
                .HasForeignKey<RegistroAsistencia>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Adjunto)
                .WithOne(x => x.RegistroAsistenciaAdjunto)
                .HasForeignKey<Adjunto>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
