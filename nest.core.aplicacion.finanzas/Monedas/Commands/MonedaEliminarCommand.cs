using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.Monedas.Commands
{
    public sealed record MonedaEliminarCommand(
        int Id
    ) : IRequest<bool>, ICommandBase;
}
