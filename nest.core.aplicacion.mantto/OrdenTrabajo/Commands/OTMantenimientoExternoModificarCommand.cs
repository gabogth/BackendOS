using System.ComponentModel.DataAnnotations;
using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Commands
{
    public sealed record OTMantenimientoExternoModificarCommand
        : OrdenTrabajoMantenimientoExternoRegistroCommand, IRequest<OrdenTrabajoCabecera>
    {
        [Range(1, long.MaxValue)]
        public long Id { get; init; }
    }
}
