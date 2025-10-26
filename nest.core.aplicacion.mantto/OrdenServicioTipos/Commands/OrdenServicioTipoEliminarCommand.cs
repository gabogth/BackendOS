using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Commands
{
    public sealed record OrdenServicioTipoEliminarCommand(short Id) : IRequest<bool>, ICommandBase;
}
