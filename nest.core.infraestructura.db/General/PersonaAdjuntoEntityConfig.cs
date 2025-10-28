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
            builder.HasIndex(pa => pa.AdjuntoId).IsUnique();
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<long>>();
            builder.HasOne(pa => pa.Persona)
               .WithMany(p => p.PersonaAdjuntos)
               .HasForeignKey(pa => pa.PersonaId)
               .HasPrincipalKey(p => p.Id)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(pa => pa.Adjunto)
                   .WithOne(a => a.PersonaAdjunto)
                   .HasForeignKey<PersonaAdjunto>(pa => pa.AdjuntoId)
                   .HasPrincipalKey<Adjunto>(x => x.Id)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.AdjuntoTipo)
                .WithMany()
                .HasForeignKey(x => x.AdjuntoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
