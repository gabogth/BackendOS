using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace nest.core.infraestructura.db.General
{
    public class DocumentoIdentidadTipoEntityConfig : IEntityTypeConfiguration<DocumentoIdentidadTipo>
    {
        public void Configure(EntityTypeBuilder<DocumentoIdentidadTipo> builder)
        {
            builder.ToTable("documento_identidad_tipo", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<DocumentoIdentidadTipoValueGenerator>();
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
    public class DocumentoIdentidadTipoValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) =>
            (entry.Context.Set<DocumentoIdentidadTipo>().Max(g => (byte?)g.Id) ?? 0) + 1;
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (await entry.Context.Set<DocumentoIdentidadTipo>().MaxAsync(g => (int?)g.Id, cancellationToken) ?? 0) + 1;
    }
}
