using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.Security.Audit;

namespace nest.core.dominio.Finanzas.FinancieroDetalleEntities
{
    public class FinancieroDetalle : IEntity<long>, IAuditable
    {
        public long Id { get; set; }
        public long FinancieroCabeceraId { get; set; }
        public short Item { get; set; }
        public int TerceroId { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaPago { get; set; }
        public int DocumentoTipoId { get; set; }
        public string SerieDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public int? CuentaCorrienteId { get; set; }
        public string ES { get; set; }
        public FinancieroCabecera FinancieroCabecera { get; set; }
        public Tercero Tercero { get; set; }
        public DocumentoTipo DocumentoTipo { get; set; }
        public CuentaCorriente CuentaCorriente { get; set; }
    }
}
