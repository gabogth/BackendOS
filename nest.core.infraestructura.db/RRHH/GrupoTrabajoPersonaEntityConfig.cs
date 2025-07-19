using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class GrupoTrabajoPersonaEntityConfig : IEntityTypeConfiguration<GrupoTrabajoPersona>
    {
        public void Configure(EntityTypeBuilder<GrupoTrabajoPersona> builder)
        {
            builder.ToTable("grupo_trabajo_persona", "rrhh");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(d => d.GrupoTrabajo)
               .WithMany(c => c.GrupoTrabajoPersonas)
               .HasForeignKey(d => d.GrupoTrabajoId)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Persona)
                .WithMany()
                .HasForeignKey(x => x.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
