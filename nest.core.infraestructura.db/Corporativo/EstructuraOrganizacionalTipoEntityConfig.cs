using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.dominio.Corporativo;

namespace nest.core.infraestructura.db.Corporativo
{
    public class EstructuraOrganizacionalTipoEntityConfig: IEntityTypeConfiguration<EstructuraOrganizacionalTipo>
    {
        public static readonly string SCHEMA = "organizacion";
        public static readonly string TABLE = "estructura_organizacional_tipo";
        public void Configure(EntityTypeBuilder<EstructuraOrganizacionalTipo> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
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
        public override int Next(EntityEntry entry) => (int)GeneradorCorrelativo.GetValue(entry.Context, EstructuraOrganizacionalTipoEntityConfig.SCHEMA, EstructuraOrganizacionalTipoEntityConfig.TABLE);
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => (int)await GeneradorCorrelativo.GetValueAsync(entry.Context, EstructuraOrganizacionalTipoEntityConfig.SCHEMA, EstructuraOrganizacionalTipoEntityConfig.TABLE, cancellationToken);
    }
}
