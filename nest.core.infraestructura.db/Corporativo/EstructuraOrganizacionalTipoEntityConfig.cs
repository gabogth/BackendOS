using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.dominio.Corporativo;

namespace nest.core.infraestructura.db.Corporativo
{
    public class EstructuraOrganizacionalTipoEntityConfig: IEntityTypeConfiguration<EstructuraOrganizacionalTipo>
    {
        public void Configure(EntityTypeBuilder<EstructuraOrganizacionalTipo> builder)
        {
            builder.ToTable("estructura_organizacional_tipo", "organizacion");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<EstructuraOrganizacionalTipoValueGenerator>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9)
                .IsRequired();
        }
    }
    public class EstructuraOrganizacionalTipoValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) =>
            (entry.Context.Set<EstructuraOrganizacionalTipo>().Max(g => (int?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<EstructuraOrganizacionalTipo>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
