using MediatR;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands
{
    public sealed record OrdenTrabajoHorarioEliminarCommand(
        long Id
    ) : IRequest<Unit>;
}
