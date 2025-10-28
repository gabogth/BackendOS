using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.infraestructura.db.General
{
    public class PersonaAdjuntoEntityConfig : IEntityTypeConfiguration<PersonaAdjunto>
    {
        public void Configure(EntityTypeBuilder<PersonaAdjunto> builder)
        {
            builder.ToTable("persona_adjunto", "dbo");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmpresaId);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(x => x.Adjunto)
                .WithOne(x => x.PersonaAdjunto)
                .HasForeignKey<Adjunto>(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.AdjuntoTipo)
                .WithMany()
                .HasForeignKey(x => x.AdjuntoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Persona)
               .WithMany(c => c.PersonaAdjuntos)
               .HasForeignKey(d => d.PersonaId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
