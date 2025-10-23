using System;
using MediatR;
using nest.core.aplicacion.general.Personas.Dtos;
using nest.core.aplicacion.general.Personas.Mappings;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Queries.GetPersonaById
{
    public class GetPersonaByIdQueryHandler : IRequestHandler<GetPersonaByIdQuery, PersonaResponseDto?>
    {
        private readonly IPersonaRepository repository;

        public GetPersonaByIdQueryHandler(IPersonaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PersonaResponseDto?> Handle(GetPersonaByIdQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            Persona? persona = await repository.ObtenerPorId(request.Id);
            return persona.ToResponseDto();
        }
    }
}
