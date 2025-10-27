using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Commands
{
    public sealed record FinancieroDetalleCrearCommand(
        int EmpresaId,
        long FinancieroCabeceraId,
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
    ) : IRequest<FinancieroDetalle>, IFinancieroDetalleGenericCommand, ICommandBase;
}
