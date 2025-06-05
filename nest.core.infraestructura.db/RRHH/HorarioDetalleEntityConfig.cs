using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class HorarioDetalleEntityConfig : IEntityTypeConfiguration<HorarioDetalle>
    {
        public static readonly string SCHEMA = "rrhh";
        public static readonly string TABLE = "horario_detalle";
        public void Configure(EntityTypeBuilder<HorarioDetalle> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
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
