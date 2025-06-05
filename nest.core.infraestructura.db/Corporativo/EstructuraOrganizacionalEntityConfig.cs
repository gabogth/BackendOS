using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.infraestructura.db.Corporativo
{
    public class EstructuraOrganizacionalEntityConfig: IEntityTypeConfiguration<EstructuraOrganizacional>
    {
        public void Configure(EntityTypeBuilder<EstructuraOrganizacional> builder)
        {
            builder.ToTable("estructura_organizacional", "organizacion");
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
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
}
