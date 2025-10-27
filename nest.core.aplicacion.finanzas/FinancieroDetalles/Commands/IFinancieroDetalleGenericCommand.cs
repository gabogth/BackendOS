namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Commands
{
    public interface IFinancieroDetalleGenericCommand
    {
        int EmpresaId { get; }
        long FinancieroCabeceraId { get; }
        short Item { get; }
        int TerceroId { get; }
        DateTime FechaEmision { get; }
        DateTime FechaVencimiento { get; }
        DateTime FechaPago { get; }
        int DocumentoTipoId { get; }
        string SerieDocumento { get; }
        string NumeroDocumento { get; }
        string Concepto { get; }
        decimal Monto { get; }
        int? CuentaCorrienteId { get; }
        string ES { get; }
    }
}
