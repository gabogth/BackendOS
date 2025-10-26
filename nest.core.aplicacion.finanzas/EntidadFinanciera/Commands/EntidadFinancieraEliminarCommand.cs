using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.EntidadFinanciera.Commands
{
    public sealed record EntidadFinancieraEliminarCommand(
        int Id
    ) : IRequest<Unit>, ICommandBase;
}
