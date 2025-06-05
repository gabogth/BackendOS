using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.General
{
    public class DocumentoTipoEntityConfig : IEntityTypeConfiguration<DocumentoTipo>
    {
        public static readonly string SCHEMA = "dbo";
        public static readonly string TABLE = "documento_tipo";
        public void Configure(EntityTypeBuilder<DocumentoTipo> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<DocumentoTipoValueGenerator>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }   
    }

    public class DocumentoTipoValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) => (int)GeneradorCorrelativo.GetValue(entry.Context, DocumentoTipoEntityConfig.SCHEMA, DocumentoTipoEntityConfig.TABLE);
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => (int)await GeneradorCorrelativo.GetValueAsync(entry.Context, DocumentoTipoEntityConfig.SCHEMA, DocumentoTipoEntityConfig.TABLE, cancellationToken);
    }
}
