using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.MantenimientoTipos.Queries;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Handlers
{
    public class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<MantenimientoTipo>>
    {
        private readonly IMantenimientoTipoRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IMantenimientoTipoRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<MantenimientoTipo>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
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
