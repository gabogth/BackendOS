using System;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Commands
{
    public interface IFinancieroDetalleGenericCommand : ICommandBase
    {
        long FinancieroCabeceraId { get; }
        int EmpresaId { get; }
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
