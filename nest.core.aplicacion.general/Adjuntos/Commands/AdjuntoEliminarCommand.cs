using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.Adjuntos.Commands
{
    public sealed record AdjuntoEliminarCommand(long Id) : IRequest<Unit>, ICommandBase;
}
