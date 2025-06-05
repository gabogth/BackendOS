using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.PersonalConfiguracionEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class PersonalConfiguracionEntityConfig : IEntityTypeConfiguration<PersonalConfiguracion>
    {
        public static readonly string SCHEMA = "rrhh";
        public static readonly string TABLE = "personal_configuracion";
        public void Configure(EntityTypeBuilder<PersonalConfiguracion> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever();
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
