using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.costos.CentroDeCostos.Commands
{
    public sealed record CentroDeCostosEliminarCommand(
        int Id
    ) : IRequest<Unit>, ICommandBase;
}
