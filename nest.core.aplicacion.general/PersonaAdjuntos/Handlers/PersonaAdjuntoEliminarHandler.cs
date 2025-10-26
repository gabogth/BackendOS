using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.PersonaAdjuntos.Commands;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Handlers
{
    public sealed class PersonaAdjuntoEliminarHandler : IRequestHandler<PersonaAdjuntoEliminarCommand, bool>
    {
        private readonly IPersonaAdjuntoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<PersonaAdjuntoEliminarHandler> logger;

        public PersonaAdjuntoEliminarHandler(
            IPersonaAdjuntoRepository repository,
            IMapper mapper,
            ILogger<PersonaAdjuntoEliminarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<bool> Handle(PersonaAdjuntoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
