using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.Financiero.Commands
{
    public sealed record FinancieroDetalleEliminarCommand(
        long Id
    ) : IRequest<Unit>, ICommandBase;
}
