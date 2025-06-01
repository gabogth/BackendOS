using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General;

namespace nest.core.infraestructura.db.General
{
    public class DocumentoTipoEntityConfig : IEntityTypeConfiguration<DocumentoTipo>
    {
        public void Configure(EntityTypeBuilder<DocumentoTipo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("documento_tipo", "dbo");
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
        }
    }
}
