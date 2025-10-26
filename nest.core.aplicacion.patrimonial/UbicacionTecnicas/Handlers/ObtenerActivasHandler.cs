using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.UbicacionTecnicas.Queries;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Handlers
{
    public class ObtenerActivasHandler : IRequestHandler<ObtenerActivasQuery, List<UbicacionTecnica>>
    {
        private readonly IUbicacionTecnicaRepository repository;
        private readonly ILogger<ObtenerActivasHandler> logger;

        public ObtenerActivasHandler(IUbicacionTecnicaRepository repository, ILogger<ObtenerActivasHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<UbicacionTecnica>> Handle(ObtenerActivasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerActivas();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las ubicaciones técnicas activas");
                throw;
            }
        }
    }
}
