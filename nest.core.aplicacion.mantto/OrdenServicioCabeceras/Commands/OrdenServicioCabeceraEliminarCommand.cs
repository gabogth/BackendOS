using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands
{
    public sealed record OrdenServicioCabeceraEliminarCommand(long Id) : IRequest<bool>, ICommandBase;
}
