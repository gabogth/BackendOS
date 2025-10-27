using AutoMapper;
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
        private readonly IMapper mapper;

        public PersonaAdjuntosUseCaseModificarHandler(
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

        public async Task<Persona> Handle(PersonaAdjuntosUseCaseModificarCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var personaDto = mapper.Map<Persona>(request);
                var personaActualizada = await personaRepository.Modificar(personaDto);
                var personaConAdjuntos = await personaRepository.ObtenerPorId(personaActualizada.Id);

                PersonaAdjunto[] originalesAdjuntos = personaConAdjuntos.PersonaAdjuntos?.ToArray() ?? Array.Empty<PersonaAdjunto>();
                PersonaAdjunto[] adjuntosDto = request.PersonaAdjuntos.Select(dto => mapper.Map<PersonaAdjunto>(dto)).ToArray();
                await personaAdjuntoRepository.FusionarRange(originalesAdjuntos, adjuntosDto);

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
