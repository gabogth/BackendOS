using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands
{
    public record OrdenTrabajoDetalleActivoEliminarCommand(
        long Id
    ) : IRequest<bool>, ICommandBase;
}
