using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Queries;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Handlers
{
    public class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<OrdenServicioTipo>>
    {
        private readonly IOrdenServicioTipoRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(IOrdenServicioTipoRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenServicioTipo>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
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
