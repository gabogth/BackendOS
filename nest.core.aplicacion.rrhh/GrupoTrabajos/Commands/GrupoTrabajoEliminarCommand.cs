using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Commands
{
    public record GrupoTrabajoEliminarCommand(long Id) : IRequest<bool>, ICommandBase;
}
