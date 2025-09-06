using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.DocumentoTipoEntities;

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
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }   
    }
}
