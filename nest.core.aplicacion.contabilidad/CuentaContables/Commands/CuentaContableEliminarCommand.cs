using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Commands
{
    public sealed record CuentaContableEliminarCommand(
        long Id
    ) : IRequest<Unit>, ICommandBase;
}
