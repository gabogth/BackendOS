using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands
{
    public sealed record OrdenTrabajoCabeceraEliminarCommand(long Id) : IRequest<bool>, ICommandBase;
}
