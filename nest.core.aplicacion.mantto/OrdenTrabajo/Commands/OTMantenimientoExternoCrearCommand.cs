using MediatR;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Commands
{
    public sealed record OTMantenimientoExternoCrearCommand(
        OrdenTrabajoCabeceraCrearCommand Cabecera,
        List<OTMantenimientoExternoDetalleCrearCommand> Detalles,
        List<OrdenTrabajoPersonalCrearCommand> Personas
    ) : IRequest<OrdenTrabajoCabecera>;
}
