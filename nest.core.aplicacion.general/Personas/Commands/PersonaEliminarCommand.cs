using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.general.Personas.Commands
{
    public record PersonaEliminarCommand(
        int Id
    ): IRequest<bool>, ICommandBase;
}
