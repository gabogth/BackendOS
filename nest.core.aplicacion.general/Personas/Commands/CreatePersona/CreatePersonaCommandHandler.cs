using System;
using MediatR;
using nest.core.aplicacion.general.Personas.Dtos;
using nest.core.aplicacion.general.Personas.Mappings;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Commands.CreatePersona
{
    public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, PersonaResponseDto>
    {
        private readonly IPersonaRepository repository;

        public CreatePersonaCommandHandler(IPersonaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PersonaResponseDto> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(request.Persona);

            Persona persona = await repository.Agregar(request.Persona.ToDomainDto());
            return PersonaResponseDto.FromEntity(persona);
        }
    }
}
