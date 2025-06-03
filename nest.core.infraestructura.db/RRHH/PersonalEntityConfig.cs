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
            builder.Property(x => x.Nombres)
                .HasMaxLength(120);
            builder.Property(x => x.ApellidoPaterno)
                .HasMaxLength(120);
            builder.Property(x => x.ApellidoMaterno)
                .HasMaxLength(120);
            builder.Property(x => x.DocumentoIdentidad)
                .HasMaxLength(25);
            builder.Property(x => x.Correo)
                .HasMaxLength(120);
            builder.Property(x => x.Celular)
                .HasMaxLength(25);
            builder.Property(x => x.Usuario)
                .HasMaxLength(90);
        }
    }
}
