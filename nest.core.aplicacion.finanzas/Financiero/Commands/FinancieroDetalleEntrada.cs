using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Commands
{
    public sealed record FinancieroDetalleEntrada(
        int EmpresaId,
        short Item,
        int TerceroId,
        DateTime FechaEmision,
        DateTime FechaVencimiento,
        DateTime FechaPago,
        int DocumentoTipoId,
        string SerieDocumento,
        string NumeroDocumento,
        string Concepto,
        decimal Monto,
        int? CuentaCorrienteId,
        string ES
    );
}
