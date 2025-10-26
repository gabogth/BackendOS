using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.PuntoFinancieros.Commands
{
    public sealed record PuntoFinancieroEliminarCommand(
        int Id
    ) : IRequest<Unit>, ICommandBase;
}
