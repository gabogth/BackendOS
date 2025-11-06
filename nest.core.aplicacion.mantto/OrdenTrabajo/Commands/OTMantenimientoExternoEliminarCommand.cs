using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Commands
{
    public sealed record OTMantenimientoExternoEliminarCommand(long Id)
        : IRequest<bool>, ICommandBase;
}
