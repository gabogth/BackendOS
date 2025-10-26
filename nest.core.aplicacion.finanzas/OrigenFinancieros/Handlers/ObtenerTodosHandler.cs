using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.OrigenFinancieros.Queries;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;

namespace nest.core.aplicacion.finanzas.OrigenFinancieros.Handlers
{
    internal class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<OrigenFinanciero>>
    {
        private readonly IOrigenFinancieroRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IOrigenFinancieroRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrigenFinanciero>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
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
