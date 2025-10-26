using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Queries;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Handlers
{
    public class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<EstructuraOrganizacional>>
    {
        private readonly IEstructuraOrganizacionalRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(IEstructuraOrganizacionalRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<EstructuraOrganizacional>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerActivos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las estructuras organizacionales activas");
                throw;
            }
        }
    }
}
