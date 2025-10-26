using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.OrigenFinancieros.Commands
{
    public sealed record OrigenFinancieroEliminarCommand(
        short Id
    ) : IRequest<Unit>, ICommandBase;
}
