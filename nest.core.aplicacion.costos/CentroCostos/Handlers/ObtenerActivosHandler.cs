using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.costos.CentroCostos.Queries;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.aplicacion.costos.CentroCostos.Handlers
{
    internal class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<CentroDeCostos>>
    {
        private readonly ICentroDeCostosRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(ICentroDeCostosRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<CentroDeCostos>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
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
