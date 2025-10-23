using System;
using MediatR;
using nest.core.aplicacion.general.Personas.Dtos;
using nest.core.aplicacion.general.Personas.Mappings;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Commands.UpdatePersona
{
    public class UpdatePersonaCommandHandler : IRequestHandler<UpdatePersonaCommand, PersonaResponseDto>
    {
        private readonly IPersonaRepository repository;

        public UpdatePersonaCommandHandler(IPersonaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PersonaResponseDto> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(request.Persona);

            Persona persona = await repository.Modificar(request.Id, request.Persona.ToDomainDto());
            return PersonaResponseDto.FromEntity(persona);
        }
    }
}
