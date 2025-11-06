using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands
{
    public interface IOrdenServicioMantenimientoExternoGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        int ClienteId { get; }
        int? ClienteSupervisorId { get; }
        long? ContratoCabeceraId { get; }
        int ClientePlannerId { get; }
        int CotizacionId { get; }
        long ActaConformidadId { get; }
        int MonedaId { get; }
        string LicitacionCodigo { get; }
        string CPI { get; }
        DateTime FechaEntregaCorreo { get; }
        DateTime FechaFianzaInicio { get; }
        DateTime FechaFianzaFinal { get; }
        decimal MontoBruto { get; }
        decimal MontoNeto { get; }
        decimal MontoFianza { get; }
        string ReporteMedicion { get; }
        string ReporteCalidad { get; }
        DateTime FechaEntregaInforme { get; }
        DateTime FechaRecepcionHES { get; }
        int NumeroHES { get; }
        short MantenimientoTipoId { get; }
        string NumeroFactura { get; }
        decimal ValorFacturadoNeto { get; }
        DateTime FechaFactura { get; }
        DateTime FechaRecepcionFactura { get; }
        DateTime FechaVencimientoFactura { get; }
        DateTime FechaPagoFactura { get; }
    }
}
