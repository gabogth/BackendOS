using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.MantenimientoTipos.Queries;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Handlers
{
    public class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<MantenimientoTipo>>
    {
        private readonly IMantenimientoTipoRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(IMantenimientoTipoRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<MantenimientoTipo>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
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
