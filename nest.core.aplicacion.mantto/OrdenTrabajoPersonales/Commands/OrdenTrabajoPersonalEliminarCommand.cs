using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands
{
    public record OrdenTrabajoPersonalEliminarCommand(
        long Id
    ) : IRequest<bool>, ICommandBase;
}
