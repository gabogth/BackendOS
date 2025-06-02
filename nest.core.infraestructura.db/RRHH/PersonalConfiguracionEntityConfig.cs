using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.PersonalConfiguracionEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class PersonalConfiguracionEntityConfig : IEntityTypeConfiguration<PersonalConfiguracion>
    {
        public void Configure(EntityTypeBuilder<PersonalConfiguracion> builder)
        {
            builder.ToTable("personal_configuracion", "rrhh");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Personal)
                .WithOne()
                .HasForeignKey<Personal>(x => x.Id)
                .HasPrincipalKey<PersonalConfiguracion>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.HorarioCabecera)
                .WithMany()
                .HasForeignKey(x => x.HorarioCabeceraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ContratoCabecera)
                .WithMany()
                .HasForeignKey(x => x.ContratoCabeceraId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
