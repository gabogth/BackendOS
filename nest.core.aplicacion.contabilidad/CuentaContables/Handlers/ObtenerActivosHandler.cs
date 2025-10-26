using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.contabilidad.CuentaContables.Queries;
using nest.core.dominio.Contabilidad.CuentaContableEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContables.Handlers
{
    internal class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<CuentaContable>>
    {
        private readonly ICuentaContableRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(ICuentaContableRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<CuentaContable>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerActivos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
