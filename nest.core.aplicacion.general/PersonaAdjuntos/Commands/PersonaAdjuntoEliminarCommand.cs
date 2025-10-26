using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Commands
{
    public sealed record PersonaAdjuntoEliminarCommand(
        long Id
    ) : IRequest<bool>, ICommandBase;
}
