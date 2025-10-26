using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Queries;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Handlers
{
    public class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<OrdenServicioTipo>>
    {
        private readonly IOrdenServicioTipoRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IOrdenServicioTipoRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenServicioTipo>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
