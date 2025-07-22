using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;

namespace nest.core.infraestructura.db.Finanzas
{
    public class OrigenFinancieroEntityConfig : IEntityTypeConfiguration<OrigenFinanciero>
    {
        public void Configure(EntityTypeBuilder<OrigenFinanciero> builder)
        {
            builder.ToTable("origen_financiero", "finanzas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<short>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.Property(x => x.Naturaleza)
                .HasMaxLength(1);
        }

        public List<OrigenFinanciero> ObtenerInformacionInicial()
        {
            List<OrigenFinanciero> entities = new List<OrigenFinanciero>()
            {
                new OrigenFinanciero { Id = 1, Nombre = "Compras nacionales", NombreCorto = "COMP_NAC", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = 2, Nombre = "Compras internacionales", NombreCorto = "COMP_INT", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = 3, Nombre = "Compras de servicios", NombreCorto = "COMP_SERV", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = 4, Nombre = "Ventas de productos", NombreCorto = "VENTA_PROD", Naturaleza = "A", Activo = true },
                new OrigenFinanciero { Id = 5, Nombre = "Ventas de servicios", NombreCorto = "VENTA_SERV", Naturaleza = "A", Activo = true },
                new OrigenFinanciero { Id = 6, Nombre = "Planillas y remuneraciones", NombreCorto = "PLANILLA", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = 7, Nombre = "Nota de crédito emitida", NombreCorto = "NC_EMITIDA", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = 8, Nombre = "Nota de crédito recibida", NombreCorto = "NC_RECIBIDA", Naturaleza = "A", Activo = true },
                new OrigenFinanciero { Id = 9, Nombre = "Anticipos de clientes", NombreCorto = "ANT_CLIENTE", Naturaleza = "A", Activo = true },
                new OrigenFinanciero { Id = 10, Nombre = "Anticipos a proveedores", NombreCorto = "ANT_PROV", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = 11, Nombre = "Reembolso a trabajadores", NombreCorto = "REEMB_TRAB", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = 12, Nombre = "Otros ingresos", NombreCorto = "OT_ING", Naturaleza = "A", Activo = true },
                new OrigenFinanciero { Id = 13, Nombre = "Otros egresos", NombreCorto = "OT_EGR", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = 14, Nombre = "Intereses y comisiones bancarias", NombreCorto = "GAS_BANC", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = 15, Nombre = "Devoluciones a clientes", NombreCorto = "DEV_CLI", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = 16, Nombre = "Devoluciones de proveedores", NombreCorto = "DEV_PROV", Naturaleza = "A", Activo = true }
            };
            return entities;
        }
    }
}
