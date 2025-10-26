using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.PuntoFinancieros.Queries;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;

namespace nest.core.aplicacion.finanzas.PuntoFinancieros.Handlers
{
    internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, PuntoFinanciero>
    {
        private readonly IPuntoFinancieroRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IPuntoFinancieroRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<PuntoFinanciero> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
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
