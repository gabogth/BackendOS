using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.PersonaAdjuntos.Queries;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Handlers
{
    public sealed class ObtenerPorPersonaHandler : IRequestHandler<ObtenerPorPersonaQuery, List<PersonaAdjunto>>
    {
        private readonly IPersonaAdjuntoRepository repository;
        private readonly ILogger<ObtenerPorPersonaHandler> logger;

        public ObtenerPorPersonaHandler(IPersonaAdjuntoRepository repository, ILogger<ObtenerPorPersonaHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<PersonaAdjunto>> Handle(ObtenerPorPersonaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorPersona(request.PersonaId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
