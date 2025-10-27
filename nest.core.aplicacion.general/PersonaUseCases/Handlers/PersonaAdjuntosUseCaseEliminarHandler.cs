using MediatR;
using nest.core.aplicacion.general.PersonaUseCases.Commands;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.PersonaUseCases.Handlers
{
    public class PersonaAdjuntosUseCaseEliminarHandler : IRequestHandler<PersonaAdjuntosUseCaseEliminarCommand, Unit>
    {
        private readonly IPersonaAdjuntosUseCaseRepository personaRepository;

        public PersonaAdjuntosUseCaseEliminarHandler(IPersonaAdjuntosUseCaseRepository personaRepository)
        {
            this.personaRepository = personaRepository;
        }

        public async Task<Unit> Handle(PersonaAdjuntosUseCaseEliminarCommand request, CancellationToken cancellationToken)
        {
            await personaRepository.Eliminar(request.Id);
            return Unit.Value;
        }
    }
}
