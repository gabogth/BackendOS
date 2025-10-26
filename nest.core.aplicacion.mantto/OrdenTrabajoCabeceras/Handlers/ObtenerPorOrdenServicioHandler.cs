using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Handlers
{
    public class ObtenerPorOrdenServicioHandler : IRequestHandler<ObtenerPorOrdenServicioQuery, List<OrdenTrabajoCabecera>>
    {
        private readonly IOrdenTrabajoCabeceraRepository repository;
        private readonly ILogger<ObtenerPorOrdenServicioHandler> logger;

        public ObtenerPorOrdenServicioHandler(IOrdenTrabajoCabeceraRepository repository, ILogger<ObtenerPorOrdenServicioHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoCabecera>> Handle(ObtenerPorOrdenServicioQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorOrdenServicio(request.OrdenServicioCabeceraId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
