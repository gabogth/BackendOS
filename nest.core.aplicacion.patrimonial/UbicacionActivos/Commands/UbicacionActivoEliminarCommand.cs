using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Commands
{
    public record UbicacionActivoEliminarCommand(
        long Id
    ) : IRequest<bool>, ICommandBase;
}
