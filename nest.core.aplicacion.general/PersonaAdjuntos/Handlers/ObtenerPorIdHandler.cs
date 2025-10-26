using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.PersonaAdjuntos.Queries;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Handlers
{
    public sealed class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, PersonaAdjunto>
    {
        private readonly IPersonaAdjuntoRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IPersonaAdjuntoRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<PersonaAdjunto> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
