using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.dominio.General;

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
                .HasValueGenerator<PersonaValueGenerator>();
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
        }
    }
    public class PersonaValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) =>
            (entry.Context.Set<Persona>().Max(g => (int?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<Persona>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
