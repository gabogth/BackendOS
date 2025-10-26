using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Distritos.Queries;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Distritos.Handlers
{
    internal class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<Distrito>>
    {
        private readonly IDistritoRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;
        public ObtenerTodosHandler(IDistritoRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public async Task<List<Distrito>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
