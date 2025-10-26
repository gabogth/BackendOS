using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.Labores.Commands
{
    public sealed record LaborEliminarCommand(
        int Id
    ) : IRequest<Unit>, ICommandBase;
}
