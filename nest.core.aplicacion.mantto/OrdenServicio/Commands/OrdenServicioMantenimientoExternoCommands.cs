using System.ComponentModel.DataAnnotations;
using MediatR;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicio.Commands
{
    public abstract record OrdenServicioMantenimientoExternoCommandBase
    {
        [Required]
        public OrdenServicioCabeceraCrearCommand Cabecera { get; init; } = default!;

        [Required]
        public OrdenServicioMantenimientoExternoCrearCommand Externo { get; init; } = default!;
    }

    public sealed record OrdenServicioMantenimientoExternoRegistrarCommand
        : OrdenServicioMantenimientoExternoCommandBase, IRequest<OrdenServicioCabecera>, ICommandBase;

    public sealed record OrdenServicioMantenimientoExternoActualizarCommand
        : OrdenServicioMantenimientoExternoCommandBase, IRequest<OrdenServicioCabecera>, ICommandBase
    {
        [Range(1, long.MaxValue)]
        public long Id { get; init; }
    }

    public sealed record OrdenServicioMantenimientoExternoEliminarCommand(long Id)
        : IRequest<bool>, ICommandBase;
}
