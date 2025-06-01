using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.General;
using nest.core.dominio.RRHH;

namespace nest.core.infraestructura.db.RRHH
{
    public class PersonalEntityConfig : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.ToTable("personal", "rrhh");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Usuario)
                .HasMaxLength(90);
            builder.HasOne(x => x.Persona)
                .WithOne()
                .HasForeignKey<Persona>(x => x.Id)
                .HasPrincipalKey<Personal>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Jefe)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.JefeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
