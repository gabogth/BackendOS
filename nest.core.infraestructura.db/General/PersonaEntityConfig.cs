using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.infraestructura.db.General
{
    public class PersonaEntityConfig : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("persona", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
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
            builder.HasOne(ic => ic.LicenciaConducir)
                .WithMany()
                .HasForeignKey(ic => ic.LicenciaConducirId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ic => ic.Sexo)
                .WithMany()
                .HasForeignKey(ic => ic.SexoId);
            builder.HasOne(ic => ic.DocumentoIdentidadTipo)
                .WithMany()
                .HasForeignKey(ic => ic.DocumentoIdentidadTipoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Ignore(x => x.NombreCompleto);
        }
    }
}
