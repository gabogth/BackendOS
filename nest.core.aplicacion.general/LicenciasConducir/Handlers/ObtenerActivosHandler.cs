using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.LicenciasConducir.Queries;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general.LicenciasConducir.Handlers
{
    public sealed class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<LicenciaConducir>>
    {
        private readonly ILicenciaConducirRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(ILicenciaConducirRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<LicenciaConducir>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
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
