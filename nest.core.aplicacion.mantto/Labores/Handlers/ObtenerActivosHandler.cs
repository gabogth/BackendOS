using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.Labores.Queries;
using nest.core.dominio.Mantto.LaborEntities;

namespace nest.core.aplicacion.mantto.Labores.Handlers
{
    internal class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<Labor>>
    {
        private readonly ILaborRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(ILaborRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<Labor>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
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
