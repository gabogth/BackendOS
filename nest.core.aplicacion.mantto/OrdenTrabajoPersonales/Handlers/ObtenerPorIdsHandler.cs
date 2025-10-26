using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Handlers
{
    public class ObtenerPorIdsHandler : IRequestHandler<ObtenerPorIdsQuery, List<OrdenTrabajoPersonal>>
    {
        private readonly IOrdenTrabajoPersonalRepository repository;
        private readonly ILogger<ObtenerPorIdsHandler> logger;

        public ObtenerPorIdsHandler(IOrdenTrabajoPersonalRepository repository, ILogger<ObtenerPorIdsHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoPersonal>> Handle(ObtenerPorIdsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorIds(request.Ids);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener el personal asignado");
                throw;
            }
        }
    }
}
