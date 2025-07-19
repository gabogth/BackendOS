using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class GrupoTrabajoEntityConfig : IEntityTypeConfiguration<GrupoTrabajo>
    {
        public void Configure(EntityTypeBuilder<GrupoTrabajo> builder)
        {
            builder.ToTable("grupo_trabajo", "rrhh");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
