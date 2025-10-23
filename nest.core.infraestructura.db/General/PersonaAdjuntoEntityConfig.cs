using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.infraestructura.db.General
{
    public class PersonaAdjuntoEntityConfig : IEntityTypeConfiguration<PersonaAdjunto>
    {
        public void Configure(EntityTypeBuilder<PersonaAdjunto> builder)
        {
            builder.ToTable("persona_adjunto", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever();
            builder.HasOne(x => x.Adjunto)
                .WithMany()
                .HasForeignKey(x => x.AdjuntoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.AdjuntoTipo)
                .WithMany()
                .HasForeignKey(x => x.AdjuntoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Persona)
               .WithMany(c => c.PersonaAdjuntos)
               .HasForeignKey(d => d.Id)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
