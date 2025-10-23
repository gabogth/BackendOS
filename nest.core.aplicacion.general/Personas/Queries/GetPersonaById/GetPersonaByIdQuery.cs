using MediatR;
using nest.core.aplicacion.general.Personas.Dtos;

namespace nest.core.aplicacion.general.Personas.Queries.GetPersonaById
{
    public record GetPersonaByIdQuery(int Id) : IRequest<PersonaResponseDto?>;
}
