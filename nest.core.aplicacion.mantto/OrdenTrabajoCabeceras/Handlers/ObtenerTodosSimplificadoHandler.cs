using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Handlers
{
    public class ObtenerTodosSimplificadoHandler : IRequestHandler<ObtenerTodosSimplificadoQuery, List<OrdenTrabajoCabeceraQueryView>>
    {
        private readonly IOrdenTrabajoCabeceraRepository repository;
        private readonly ILogger<ObtenerTodosSimplificadoHandler> logger;

        public ObtenerTodosSimplificadoHandler(IOrdenTrabajoCabeceraRepository repository, ILogger<ObtenerTodosSimplificadoHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoCabeceraQueryView>> Handle(ObtenerTodosSimplificadoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodosSimplificado();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
