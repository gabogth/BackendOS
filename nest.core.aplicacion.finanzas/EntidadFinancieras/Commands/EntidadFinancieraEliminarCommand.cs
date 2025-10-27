using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.EntidadFinancieras.Commands
{
    public sealed record EntidadFinancieraEliminarCommand(
        int Id
    ) : IRequest<bool>, ICommandBase;
}
