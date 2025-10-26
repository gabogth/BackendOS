using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.PersonaAdjuntos.Commands;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Handlers
{
    public sealed class PersonaAdjuntoCrearHandler : IRequestHandler<PersonaAdjuntoCrearCommand, PersonaAdjunto>
    {
        private readonly IPersonaAdjuntoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<PersonaAdjuntoCrearHandler> logger;

        public PersonaAdjuntoCrearHandler(
            IPersonaAdjuntoRepository repository,
            IMapper mapper,
            ILogger<PersonaAdjuntoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<PersonaAdjunto> Handle(PersonaAdjuntoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<PersonaAdjunto>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
