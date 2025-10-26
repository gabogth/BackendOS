using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands
{
    public sealed record OrdenServicioMantenimientoExternoEliminarCommand(long Id) : IRequest<bool>, ICommandBase;
}
