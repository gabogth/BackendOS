using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Legal;

namespace nest.core.infraestructura.db.Legal
{
    internal class ContratoTipoEntityConfig : IEntityTypeConfiguration<ContratoTipo>
    {
        public void Configure(EntityTypeBuilder<ContratoTipo> builder)
        {
            builder.ToTable("contrato_tipo", "legal");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<ContratoTipoValueGenerator>();
            builder.Property(x => x.Detalle).HasMaxLength(800);
            builder.HasData(ObtenerInformacionInicial());
        }

        public List<ContratoTipo> ObtenerInformacionInicial()
        {
            List<ContratoTipo> roles = new List<ContratoTipo>()
            {
                new ContratoTipo { Id = 1, Nombre = "CONTRATO DE PRESTACION DE SERVICIOS", Detalle = "CONTRATO DE PRESTACION DE SERVICIOS" },
                new ContratoTipo { Id = 2, Nombre = "CONTRATO POR INCREMENTO DE OBRA", Detalle = "CONTRATO POR INCREMENTO DE OBRA" },
                new ContratoTipo { Id = 3, Nombre = "CAS", Detalle = "CONTRATACION ADMINISTRATIVA DE SERVICIOS" },
                new ContratoTipo { Id = 4, Nombre = "RECIBO POR HONORARIOS", Detalle = "RECIBO POR HONORARIOS" }
            };
            return roles;
        }
    }
    public class ContratoTipoValueGenerator : ValueGenerator<byte>
    {
        public override bool GeneratesTemporaryValues => false;
        public override byte Next(EntityEntry entry) =>
            (byte)((entry.Context.Set<ContratoTipo>().Max(g => (byte?)g.Id) ?? 0) + 1);
        public override async ValueTask<byte> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) =>
            (byte)((await entry.Context.Set<ContratoTipo>().MaxAsync(g => (byte?)g.Id, cancellationToken) ?? 0) + 1);
    }
}
