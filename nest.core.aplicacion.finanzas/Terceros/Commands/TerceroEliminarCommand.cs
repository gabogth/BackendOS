using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.Terceros.Commands
{
    public sealed record TerceroEliminarCommand(
        int Id
    ) : IRequest<Unit>, ICommandBase;
}
