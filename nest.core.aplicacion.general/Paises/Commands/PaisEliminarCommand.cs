using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.Paises.Commands
{
    public sealed record PaisEliminarCommand(int Id) : IRequest<Unit>, ICommandBase;
}
