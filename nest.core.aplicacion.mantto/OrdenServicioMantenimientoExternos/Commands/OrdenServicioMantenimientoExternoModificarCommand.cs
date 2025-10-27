using MediatR;
using System;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands
{
    public sealed record OrdenServicioMantenimientoExternoModificarCommand(
        long Id,
        int EmpresaId,
        int ClienteId,
        int? ClienteSupervisorId,
        long? ContratoCabeceraId,
        int ClientePlannerId,
        int CotizacionId,
        long ActaConformidadId,
        int MonedaId,
        string LicitacionCodigo,
        string CPI,
        DateTime FechaEntregaCorreo,
        DateTime FechaFianzaInicio,
        DateTime FechaFianzaFinal,
        decimal MontoBruto,
        decimal MontoNeto,
        decimal MontoFianza,
        string ReporteMedicion,
        string ReporteCalidad,
        DateTime FechaEntregaInforme,
        DateTime FechaRecepcionHES,
        int NumeroHES,
        short MantenimientoTipoId,
        string NumeroFactura,
        decimal ValorFacturadoNeto,
        DateTime FechaFactura,
        DateTime FechaRecepcionFactura,
        DateTime FechaVencimientoFactura,
        DateTime FechaPagoFactura
    ) : IRequest<OrdenServicioMantenimientoExterno>, IOrdenServicioMantenimientoExternoGenericCommand;
}
