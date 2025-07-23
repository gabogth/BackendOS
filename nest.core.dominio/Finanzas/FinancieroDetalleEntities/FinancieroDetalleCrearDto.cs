namespace nest.core.dominio.Finanzas.FinancieroDetalleEntities
{
    public class FinancieroDetalleCrearDto
    {
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
    }
}
