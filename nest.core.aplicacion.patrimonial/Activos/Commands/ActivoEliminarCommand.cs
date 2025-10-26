using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.patrimonial.Activos.Commands
{
    public record ActivoEliminarCommand(
        long Id
    ) : IRequest<bool>, ICommandBase;
}
