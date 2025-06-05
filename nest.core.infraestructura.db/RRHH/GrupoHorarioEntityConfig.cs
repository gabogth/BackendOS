using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.GrupoHorarioEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class GrupoHorarioEntityConfig : IEntityTypeConfiguration<GrupoHorario>
    {
        public static readonly string SCHEMA = "rrhh";
        public static readonly string TABLE = "grupo_horario";
        public void Configure(EntityTypeBuilder<GrupoHorario> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
