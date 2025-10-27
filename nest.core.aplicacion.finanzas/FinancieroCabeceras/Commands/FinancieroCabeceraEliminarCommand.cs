using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Commands
{
    public sealed record FinancieroCabeceraEliminarCommand(
        long Id
    ) : IRequest<Unit>, ICommandBase;
}
