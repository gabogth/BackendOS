using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;

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
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9)
                .IsRequired();
        }
    }
}
