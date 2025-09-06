using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.infraestructura.db.RRHH
{
    public class PersonalEntityConfig : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.ToTable("personal", "rrhh");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever();
            builder.HasOne(x => x.Persona)
                .WithMany()
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.HorarioCabecera)
                .WithMany()
                .HasForeignKey(x => x.HorarioCabeceraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ContratoCabecera)
                .WithMany()
                .HasForeignKey(x => x.ContratoCabeceraId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Superior)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.SuperiorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.PersonalEstado)
                .WithMany()
                .HasForeignKey(x => x.PersonalEstadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
