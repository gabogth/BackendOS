using MediatR;
using nest.core.aplicacion.general.Personas.Dtos;

namespace nest.core.aplicacion.general.Personas.Commands.UpdatePersona
{
    public record UpdatePersonaCommand(int Id, PersonaCreateDto Persona) : IRequest<PersonaResponseDto>;
}
