using System.Collections.Generic;
using MediatR;
using nest.core.aplicacion.general.Personas.Dtos;
using nest.core.aplicacion.general.Personas.Mappings;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Queries.GetPersonasActivas
{
    public class GetPersonasActivasQueryHandler : IRequestHandler<GetPersonasActivasQuery, List<PersonaResponseDto>>
    {
        private readonly IPersonaRepository repository;

        public GetPersonasActivasQueryHandler(IPersonaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<PersonaResponseDto>> Handle(GetPersonasActivasQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyCollection<Persona> personas = await repository.ObtenerActivos();
            return personas.ToResponseDtoList();
        }
    }
}
