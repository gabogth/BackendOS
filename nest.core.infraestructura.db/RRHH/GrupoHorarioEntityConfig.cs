using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.GrupoHorarioEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class GrupoHorarioEntityConfig : IEntityTypeConfiguration<GrupoHorario>
    {
        public void Configure(EntityTypeBuilder<GrupoHorario> builder)
        {
            builder.ToTable("grupo_horario", "rrhh");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
