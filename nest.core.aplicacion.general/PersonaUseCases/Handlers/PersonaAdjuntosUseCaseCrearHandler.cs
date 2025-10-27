using AutoMapper;
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
        private readonly IMapper mapper;

        public PersonaAdjuntosUseCaseCrearHandler(
            IPersonaAdjuntosUseCaseRepository personaRepository,
            IPersonaAdjuntoRepository personaAdjuntoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.personaRepository = personaRepository;
            this.personaAdjuntoRepository = personaAdjuntoRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Persona> Handle(PersonaAdjuntosUseCaseCrearCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var personaDto = mapper.Map<Persona>(request);
                var persona = await personaRepository.Agregar(personaDto);
                PersonaAdjunto[] adjuntos = request.PersonaAdjuntos.Select(dto => mapper.Map<PersonaAdjunto>(dto)).ToArray();
                if (adjuntos.Length > 0)
                    await personaAdjuntoRepository.AgregarRange(adjuntos);
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
