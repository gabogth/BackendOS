using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.AdjuntoConfigProviders.Queries;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Handlers
{
    internal class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<AdjuntoConfigProvider>>
    {
        private readonly IAdjuntoConfigProviderRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(IAdjuntoConfigProviderRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<AdjuntoConfigProvider>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerActivos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
