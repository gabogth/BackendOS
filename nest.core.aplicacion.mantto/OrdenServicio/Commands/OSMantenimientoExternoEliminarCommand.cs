using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicio.Commands
{
    public sealed record OSMantenimientoExternoEliminarCommand(long Id)
        : IRequest<bool>, ICommandBase;
}
