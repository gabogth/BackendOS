using MediatR;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Commands
{
    public sealed record OTMantenimientoExternoModificarCommand(
        long Id,
        OrdenTrabajoCabeceraModificarCommand Cabecera,
        List<OTMantenimientoExternoDetalleModificarCommand> Detalles,
        List<OrdenTrabajoPersonalModificarCommand> Personas
    ) : IRequest<OrdenTrabajoCabecera>;
}
