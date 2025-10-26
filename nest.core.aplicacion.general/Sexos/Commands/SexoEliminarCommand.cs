using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.Sexos.Commands
{
    public sealed record SexoEliminarCommand(byte Id) : IRequest<Unit>, ICommandBase;
}
