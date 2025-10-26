using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Moneda.Queries;
using nest.core.dominio.Finanzas.MonedaEntities;

namespace nest.core.aplicacion.finanzas.Moneda.Handlers
{
    internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, Moneda>
    {
        private readonly IMonedaRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IMonedaRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Moneda> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
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
