using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.dominio.Corporativo;

namespace nest.core.infraestructura.db.Corporativo
{
    public class EstructuraOrganizacionalEntityConfig: IEntityTypeConfiguration<EstructuraOrganizacional>
    {
        public void Configure(EntityTypeBuilder<EstructuraOrganizacional> builder)
        {
            builder.ToTable("estructura_organizacional", "organizacion");
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<EstructuraOrganizacionalValueGenerator>();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9)
                .IsRequired();
            builder.HasOne(ic => ic.EstructuraOrganizacionalTipo)
                .WithMany()
                .HasForeignKey(ic => ic.EstructuraOrganizacionalTipoId);
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class EstructuraOrganizacionalValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) =>
            (entry.Context.Set<EstructuraOrganizacional>().Max(g => (int?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<EstructuraOrganizacional>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
