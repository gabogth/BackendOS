using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Legal;

namespace nest.core.infraestructura.db.Legal
{
    public class ContratoPersonalEntityConfig : IEntityTypeConfiguration<ContratoPersonal>
    {
        public void Configure(EntityTypeBuilder<ContratoPersonal> builder)
        {
            builder.ToTable("contrato_personal", "legal");
            builder.HasKey(x => x.ContratoCabeceraId);
            builder.Property(x => x.ContratoCabeceraId)
                .ValueGeneratedNever();
            builder.HasOne(x => x.Personal)
                .WithMany()
                .HasForeignKey(x => x.PersonalId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Cargo)
                .WithMany()
                .HasForeignKey(x => x.CargoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.EstructuraOrganizacional)
                .WithMany()
                .HasForeignKey(x => x.EstructuraOrganizacionalId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.ContratoCabecera)
                .WithOne()
                .HasForeignKey<ContratoCabecera>(p => p.Id)
                .HasPrincipalKey<ContratoPersonal>(p => p.ContratoCabeceraId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
