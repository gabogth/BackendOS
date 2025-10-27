using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Queries;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;

namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Handlers
{
    internal class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<CuentaCorriente>>
    {
        private readonly ICuentaCorrienteRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(ICuentaCorrienteRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<CuentaCorriente>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
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
