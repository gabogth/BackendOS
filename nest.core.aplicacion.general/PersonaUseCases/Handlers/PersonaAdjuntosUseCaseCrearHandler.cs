using MediatR;
using nest.core.aplicacion.general.PersonaUseCases.Commands;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.general.PersonaUseCases.Handlers
{
    public class PersonaAdjuntosUseCaseCrearHandler : IRequestHandler<PersonaAdjuntosUseCaseCrearCommand, Persona>
    {
        private readonly IPersonaAdjuntosUseCaseRepository personaRepository;
        private readonly IPersonaAdjuntoRepository personaAdjuntoRepository;
        private readonly IUnitOfWork unitOfWork;

        public PersonaAdjuntosUseCaseCrearHandler(
            IPersonaAdjuntosUseCaseRepository personaRepository,
            IPersonaAdjuntoRepository personaAdjuntoRepository,
            IUnitOfWork unitOfWork)
        {
            this.personaRepository = personaRepository;
            this.personaAdjuntoRepository = personaAdjuntoRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Persona> Handle(PersonaAdjuntosUseCaseCrearCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var persona = await personaRepository.Agregar(PersonaAdjuntosUseCaseMapper.ToPersona(request));

                PersonaAdjunto[] adjuntos = PersonaAdjuntosUseCaseMapper.ToAdjuntos(request, persona);
                if (adjuntos.Length > 0)
                {
                    await personaAdjuntoRepository.AgregarRange(adjuntos);
                }

                await unitOfWork.CommitAsync();
                return await personaRepository.ObtenerPorId(persona.Id);
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
