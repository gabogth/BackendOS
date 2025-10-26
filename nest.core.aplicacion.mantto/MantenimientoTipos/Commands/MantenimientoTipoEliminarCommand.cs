using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Commands
{
    public sealed record MantenimientoTipoEliminarCommand(short Id) : IRequest<bool>, ICommandBase;
}
