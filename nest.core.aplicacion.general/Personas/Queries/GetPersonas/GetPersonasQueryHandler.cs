using System.Collections.Generic;
using MediatR;
using nest.core.aplicacion.general.Personas.Dtos;
using nest.core.aplicacion.general.Personas.Mappings;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Queries.GetPersonas
{
    public class GetPersonasQueryHandler : IRequestHandler<GetPersonasQuery, List<PersonaResponseDto>>
    {
        private readonly IPersonaRepository repository;

        public GetPersonasQueryHandler(IPersonaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<PersonaResponseDto>> Handle(GetPersonasQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyCollection<Persona> personas = await repository.ObtenerTodos();
            return personas.ToResponseDtoList();
        }
    }
}
