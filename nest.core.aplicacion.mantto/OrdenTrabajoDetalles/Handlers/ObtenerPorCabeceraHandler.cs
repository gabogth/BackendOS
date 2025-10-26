using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Handlers
{
    public class ObtenerPorCabeceraHandler : IRequestHandler<ObtenerPorCabeceraQuery, List<OrdenTrabajoDetalle>>
    {
        private readonly IOrdenTrabajoDetalleRepository repository;
        private readonly ILogger<ObtenerPorCabeceraHandler> logger;

        public ObtenerPorCabeceraHandler(IOrdenTrabajoDetalleRepository repository, ILogger<ObtenerPorCabeceraHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoDetalle>> Handle(ObtenerPorCabeceraQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorCabecera(request.OrdenTrabajoCabeceraId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los detalles de la cabecera {CabeceraId}", request.OrdenTrabajoCabeceraId);
                throw;
            }
        }
    }
}
