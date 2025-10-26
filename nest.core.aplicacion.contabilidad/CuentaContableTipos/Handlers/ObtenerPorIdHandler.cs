using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.contabilidad.CuentaContableTipos.Queries;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.aplicacion.contabilidad.CuentaContableTipos.Handlers
{
    internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, CuentaContableTipo>
    {
        private readonly ICuentaContableTipoRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(ICuentaContableTipoRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<CuentaContableTipo> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
