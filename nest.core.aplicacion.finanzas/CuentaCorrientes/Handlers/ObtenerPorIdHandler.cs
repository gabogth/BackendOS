using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Queries;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;

namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Handlers
{
    internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, CuentaCorriente>
    {
        private readonly ICuentaCorrienteRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(ICuentaCorrienteRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<CuentaCorriente> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
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
