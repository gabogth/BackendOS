using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Handlers
{
    public class ObtenerPorIdsHandler : IRequestHandler<ObtenerPorIdsQuery, List<OrdenTrabajoDetalle>>
    {
        private readonly IOrdenTrabajoDetalleRepository repository;
        private readonly ILogger<ObtenerPorIdsHandler> logger;

        public ObtenerPorIdsHandler(IOrdenTrabajoDetalleRepository repository, ILogger<ObtenerPorIdsHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoDetalle>> Handle(ObtenerPorIdsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorIds(request.Ids);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los detalles de orden para los identificadores proporcionados");
                throw;
            }
        }
    }
}
