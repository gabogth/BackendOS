using MediatR;
using nest.core.aplicacion.general.PersonaUseCases.Commands;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.general.PersonaUseCases.Handlers
{
    public class PersonaAdjuntosUseCaseModificarHandler : IRequestHandler<PersonaAdjuntosUseCaseModificarCommand, Persona>
    {
        private readonly IPersonaAdjuntosUseCaseRepository personaRepository;
        private readonly IPersonaAdjuntoRepository personaAdjuntoRepository;
        private readonly IUnitOfWork unitOfWork;

        public PersonaAdjuntosUseCaseModificarHandler(
            IPersonaAdjuntosUseCaseRepository personaRepository,
            IPersonaAdjuntoRepository personaAdjuntoRepository,
            IUnitOfWork unitOfWork)
        {
            this.personaRepository = personaRepository;
            this.personaAdjuntoRepository = personaAdjuntoRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Persona> Handle(PersonaAdjuntosUseCaseModificarCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var personaActualizada = await personaRepository.Modificar(PersonaAdjuntosUseCaseMapper.ToPersona(request, request.Id));
                var personaConAdjuntos = await personaRepository.ObtenerPorId(personaActualizada.Id);

                PersonaAdjunto[] originalesAdjuntos = personaConAdjuntos.PersonaAdjuntos?.ToArray() ?? Array.Empty<PersonaAdjunto>();
                PersonaAdjunto[] adjuntosActualizados = PersonaAdjuntosUseCaseMapper.ToAdjuntos(request, personaConAdjuntos);

                await personaAdjuntoRepository.FusionarRange(originalesAdjuntos, adjuntosActualizados);

                await unitOfWork.CommitAsync();
                return await personaRepository.ObtenerPorId(personaActualizada.Id);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }
}
