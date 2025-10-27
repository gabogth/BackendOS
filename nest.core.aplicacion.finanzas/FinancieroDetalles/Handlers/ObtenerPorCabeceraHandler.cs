using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.FinancieroDetalles.Queries;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Handlers
{
    internal class ObtenerPorCabeceraHandler : IRequestHandler<ObtenerPorCabeceraQuery, List<FinancieroDetalle>>
    {
        private readonly IFinancieroDetalleRepository repository;
        private readonly ILogger<ObtenerPorCabeceraHandler> logger;

        public ObtenerPorCabeceraHandler(IFinancieroDetalleRepository repository, ILogger<ObtenerPorCabeceraHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<FinancieroDetalle>> Handle(ObtenerPorCabeceraQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorCabecera(request.FinancieroCabeceraId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
