using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Finanzas.FinancieroCabeceraEntities
{
    public class FinancieroCabecera : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public int PuntoFinancieroId { get; set; }
        public int Numero { get; set; }
        public OrigenFinancieroEnum OrigenFinancieroId { get; set; }
        public EstadoFinancieroEnum Estado { get; set; }
        public string Comentarios { get; set; }
        public int TerceroGenId { get; set; }
        public int DocumentoTipoGenId { get; set; }
        public string SerieDocumentoGen { get; set; }
        public string NumeroDocumentoGen { get; set; }
        public PuntoFinanciero PuntoFinanciero { get; set; }
        public OrigenFinanciero OrigenFinanciero { get; set; }
        public Tercero TerceroGen { get; set; }
        public DocumentoTipo DocumentoTipoGen { get; set; }
        public List<FinancieroDetalle> FinancieroDetalles { get; set; }
    }
    public enum EstadoFinancieroEnum : byte
    {
        Activo = 1,
        PendienteRevision = 2,
        Cerrado = 3
    }

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
