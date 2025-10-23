using MediatR;
using nest.core.aplicacion.general.Personas.Dtos;

namespace nest.core.aplicacion.general.Personas.Queries.GetPersonasActivas
{
    public record GetPersonasActivasQuery() : IRequest<List<PersonaResponseDto>>;
}
