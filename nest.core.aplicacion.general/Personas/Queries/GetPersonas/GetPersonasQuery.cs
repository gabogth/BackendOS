using MediatR;
using nest.core.aplicacion.general.Personas.Dtos;

namespace nest.core.aplicacion.general.Personas.Queries.GetPersonas
{
    public record GetPersonasQuery() : IRequest<List<PersonaResponseDto>>;
}
