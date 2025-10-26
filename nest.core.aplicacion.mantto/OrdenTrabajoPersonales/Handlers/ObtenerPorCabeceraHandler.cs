using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Handlers
{
    public class ObtenerPorCabeceraHandler : IRequestHandler<ObtenerPorCabeceraQuery, List<OrdenTrabajoPersonal>>
    {
        private readonly IOrdenTrabajoPersonalRepository repository;
        private readonly ILogger<ObtenerPorCabeceraHandler> logger;

        public ObtenerPorCabeceraHandler(IOrdenTrabajoPersonalRepository repository, ILogger<ObtenerPorCabeceraHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoPersonal>> Handle(ObtenerPorCabeceraQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorCabecera(request.OrdenTrabajoCabeceraId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener el personal de la orden {OrdenId}", request.OrdenTrabajoCabeceraId);
                throw;
            }
        }
    }
}
