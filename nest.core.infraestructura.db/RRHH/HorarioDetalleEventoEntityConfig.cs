using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class HorarioDetalleEventoEntityConfig : IEntityTypeConfiguration<HorarioDetalleEvento>
    {
        public void Configure(EntityTypeBuilder<HorarioDetalleEvento> builder)
        {
            builder.ToTable("horario_detalle_evento", "rrhh");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.Property(x => x.Id)
                .ValueGeneratedNever();
            builder.HasOne(x => x.HorarioDetalle)
                .WithMany(x => x.HorarioDetalleEventos)
                .HasForeignKey(x => x.HorarioDetalleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
