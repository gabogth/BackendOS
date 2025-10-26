using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.Distritos.Commands
{
    public record DistritoEliminarCommand(
        int Id
    ): IRequest<bool>, ICommandBase;
}
