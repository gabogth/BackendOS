using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Commands
{
    public sealed record FinancieroDetalleModificarCommand(
        long Id,
        long FinancieroCabeceraId,
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
    ) : IRequest<FinancieroDetalle>, IFinancieroDetalleGenericCommand;
}
