using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class HorarioCabeceraEntityConfig : IEntityTypeConfiguration<HorarioCabecera>
    {
        public static readonly string SCHEMA = "rrhh";
        public static readonly string TABLE = "horario_cabecera";
        public void Configure(EntityTypeBuilder<HorarioCabecera> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
        }
    }
}
