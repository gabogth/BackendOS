using MediatR;

namespace nest.core.aplicacion.general.Personas.Commands.DeletePersona
{
    public record DeletePersonaCommand(int Id) : IRequest<Unit>;
}
