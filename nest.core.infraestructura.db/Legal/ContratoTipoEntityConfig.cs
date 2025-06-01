using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Legal;

namespace nest.core.infraestructura.db.Legal
{
    internal class ContratoTipoEntityConfig : IEntityTypeConfiguration<ContratoTipo>
    {
        public void Configure(EntityTypeBuilder<ContratoTipo> builder)
        {
            builder.ToTable("contrato_tipo", "legal");
            builder.HasKey(x => x.Id);
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
}
