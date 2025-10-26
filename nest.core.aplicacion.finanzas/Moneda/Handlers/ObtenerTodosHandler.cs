using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Moneda.Queries;
using nest.core.dominio.Finanzas.MonedaEntities;

namespace nest.core.aplicacion.finanzas.Moneda.Handlers
{
    internal class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<Moneda>>
    {
        private readonly IMonedaRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IMonedaRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<Moneda>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
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
