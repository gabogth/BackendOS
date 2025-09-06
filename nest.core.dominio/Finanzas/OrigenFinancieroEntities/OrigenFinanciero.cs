using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Finanzas.OrigenFinancieroEntities
{
    public class OrigenFinanciero : IEntity<short>, IAuditable
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Naturaleza { get; set; }
        public bool Activo { get; set; }

        public enum OrigenFinancieroEnum : short
        {
            COMPRAS_NACIONALES = 1,
            COMPRAS_INTERNACIONALES = 2,
            COMPRAS_SERVICIOS = 3,
            VENTA_PRODUCTOS = 4,
            VENTA_SERVICIOS = 5,
            PLANILLA = 6,
            NOTA_CREDITO_EMITIDA = 7,
            NOTA_CREDITO_RECIBIDA = 8,
            ANTICIPO_CLIENTE = 9,
            ANTICIPO_PROVEEDOR = 10,
            REEMBOLSO_TRABAJADOR = 11,
            OTROS_INGRESOS = 12,
            OTROS_EGRESOS = 13,
            COMISIONES_BANCARIOS = 14,
            DEVOLUCIONES_CLIENTES = 15,
            DEVOLUCIONES_PROVEEDORES = 16
        }
    }
}
