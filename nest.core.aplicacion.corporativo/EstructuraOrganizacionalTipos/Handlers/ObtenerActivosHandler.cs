using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Queries;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Handlers
{
    public class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<EstructuraOrganizacionalTipo>>
    {
        private readonly IEstructuraOrganizacionalTipoRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(IEstructuraOrganizacionalTipoRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<EstructuraOrganizacionalTipo>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerActivos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los tipos de estructura organizacional activos");
                throw;
            }
        }
    }
}
