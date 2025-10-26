using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.PersonaAdjuntos.Commands;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Handlers
{
    public sealed class PersonaAdjuntoModificarHandler : IRequestHandler<PersonaAdjuntoModificarCommand, PersonaAdjunto>
    {
        private readonly IPersonaAdjuntoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<PersonaAdjuntoModificarHandler> logger;

        public PersonaAdjuntoModificarHandler(
            IPersonaAdjuntoRepository repository,
            IMapper mapper,
            ILogger<PersonaAdjuntoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<PersonaAdjunto> Handle(PersonaAdjuntoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<PersonaAdjunto>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
