using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands
{
    public record OrdenTrabajoDetalleEliminarCommand(
        long Id
    ) : IRequest<bool>, ICommandBase;
}
