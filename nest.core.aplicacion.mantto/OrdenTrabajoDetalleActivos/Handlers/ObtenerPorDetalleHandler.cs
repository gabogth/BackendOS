using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Handlers
{
    public class ObtenerPorDetalleHandler : IRequestHandler<ObtenerPorDetalleQuery, List<OrdenTrabajoDetalleActivo>>
    {
        private readonly IOrdenTrabajoDetalleActivoRepository repository;
        private readonly ILogger<ObtenerPorDetalleHandler> logger;

        public ObtenerPorDetalleHandler(IOrdenTrabajoDetalleActivoRepository repository, ILogger<ObtenerPorDetalleHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoDetalleActivo>> Handle(ObtenerPorDetalleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorDetalle(request.OrdenTrabajoDetalleId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los activos para el detalle {DetalleId}", request.OrdenTrabajoDetalleId);
                throw;
            }
        }
    }
}
