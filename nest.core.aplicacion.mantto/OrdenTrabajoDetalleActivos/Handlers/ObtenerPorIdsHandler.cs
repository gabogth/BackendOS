using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Handlers
{
    public class ObtenerPorIdsHandler : IRequestHandler<ObtenerPorIdsQuery, List<OrdenTrabajoDetalleActivo>>
    {
        private readonly IOrdenTrabajoDetalleActivoRepository repository;
        private readonly ILogger<ObtenerPorIdsHandler> logger;

        public ObtenerPorIdsHandler(IOrdenTrabajoDetalleActivoRepository repository, ILogger<ObtenerPorIdsHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoDetalleActivo>> Handle(ObtenerPorIdsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorIds(request.Ids);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los activos de detalle para los identificadores especificados");
                throw;
            }
        }
    }
}
