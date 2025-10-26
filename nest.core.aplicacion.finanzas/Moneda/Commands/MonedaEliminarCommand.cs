using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.Moneda.Commands
{
    public sealed record MonedaEliminarCommand(
        int Id
    ) : IRequest<Unit>, ICommandBase;
}
