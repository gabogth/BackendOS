using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.Horarios.Commands
{
    public record HorarioEliminarCommand(int Id) : IRequest<bool>, ICommandBase;
}
