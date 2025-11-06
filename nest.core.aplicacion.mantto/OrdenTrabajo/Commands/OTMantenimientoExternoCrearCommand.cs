using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Commands
{
    public sealed record OTMantenimientoExternoCrearCommand
        : OrdenTrabajoMantenimientoExternoRegistroCommand, IRequest<OrdenTrabajoCabecera>;
}
