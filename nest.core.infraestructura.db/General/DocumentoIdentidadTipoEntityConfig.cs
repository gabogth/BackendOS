using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General;

namespace nest.core.infraestructura.db.General
{
    public class DocumentoIdentidadTipoEntityConfig : IEntityTypeConfiguration<DocumentoIdentidadTipo>
    {
        public void Configure(EntityTypeBuilder<DocumentoIdentidadTipo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.HasData(GetData());
        }

        private List<DocumentoIdentidadTipo> GetData()
        {
            return new List<DocumentoIdentidadTipo>
            {
                new DocumentoIdentidadTipo { Id = 1, Nombre = "Documento nacional de identidad", NombreCorto = "DNI" },
                new DocumentoIdentidadTipo { Id = 2, Nombre = "Carnet de extranjería", NombreCorto = "CE" },
                new DocumentoIdentidadTipo { Id = 3, Nombre = "Pasaporte", NombreCorto = "PSX" },
                new DocumentoIdentidadTipo { Id = 4, Nombre = "Permiso temporal de permanencia", NombreCorto = "PTP" }
            };
        }
    }
}
