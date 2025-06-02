using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class HorarioDetalleEntityConfig : IEntityTypeConfiguration<HorarioDetalle>
    {
        public void Configure(EntityTypeBuilder<HorarioDetalle> builder)
        {
            builder.ToTable("horario_detalle", "rrhh");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.HorarioCabecera)
                .WithMany(x => x.HorarioDetalles)
                .HasForeignKey(x => x.HorarioCabeceraId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.GrupoHorario)
                .WithMany()
                .HasForeignKey(x => x.GrupoHorarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
