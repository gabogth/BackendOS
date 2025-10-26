using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Provincias.Queries;
using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.aplicacion.general.Provincias.Handlers
{
    public class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<Provincia>>
    {
        private readonly IProvinciaRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(IProvinciaRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<Provincia>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
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
