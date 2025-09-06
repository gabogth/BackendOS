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
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.COMPRAS_NACIONALES, Nombre = "Compras nacionales", NombreCorto = "COMP_NAC", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.COMPRAS_INTERNACIONALES, Nombre = "Compras internacionales", NombreCorto = "COMP_INT", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.COMPRAS_SERVICIOS, Nombre = "Compras de servicios", NombreCorto = "COMP_SERV", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.VENTA_PRODUCTOS, Nombre = "Ventas de productos", NombreCorto = "VENTA_PROD", Naturaleza = "A", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.VENTA_SERVICIOS, Nombre = "Ventas de servicios", NombreCorto = "VENTA_SERV", Naturaleza = "A", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.PLANILLA, Nombre = "Planillas y remuneraciones", NombreCorto = "PLANILLA", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.NOTA_CREDITO_EMITIDA, Nombre = "Nota de crédito emitida", NombreCorto = "NC_EMITIDA", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.NOTA_CREDITO_RECIBIDA, Nombre = "Nota de crédito recibida", NombreCorto = "NC_RECIBIDA", Naturaleza = "A", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.ANTICIPO_CLIENTE, Nombre = "Anticipos de clientes", NombreCorto = "ANT_CLIENTE", Naturaleza = "A", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.ANTICIPO_PROVEEDOR, Nombre = "Anticipos a proveedores", NombreCorto = "ANT_PROV", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.REEMBOLSO_TRABAJADOR, Nombre = "Reembolso a trabajadores", NombreCorto = "REEMB_TRAB", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.OTROS_INGRESOS, Nombre = "Otros ingresos", NombreCorto = "OT_ING", Naturaleza = "A", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.OTROS_EGRESOS, Nombre = "Otros egresos", NombreCorto = "OT_EGR", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.COMISIONES_BANCARIOS, Nombre = "Intereses y comisiones bancarias", NombreCorto = "GAS_BANC", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.DEVOLUCIONES_CLIENTES, Nombre = "Devoluciones a clientes", NombreCorto = "DEV_CLI", Naturaleza = "D", Activo = true },
                new OrigenFinanciero { Id = (short)OrigenFinanciero.OrigenFinancieroEnum.DEVOLUCIONES_PROVEEDORES, Nombre = "Devoluciones de proveedores", NombreCorto = "DEV_PROV", Naturaleza = "A", Activo = true }
            };
            return entities;
        }
    }
}
