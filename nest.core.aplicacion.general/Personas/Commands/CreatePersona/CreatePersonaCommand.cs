using MediatR;
using nest.core.aplicacion.general.Personas.Dtos;

namespace nest.core.aplicacion.general.Personas.Commands.CreatePersona
{
    public record CreatePersonaCommand(PersonaCreateDto Persona) : IRequest<PersonaResponseDto>;
}
