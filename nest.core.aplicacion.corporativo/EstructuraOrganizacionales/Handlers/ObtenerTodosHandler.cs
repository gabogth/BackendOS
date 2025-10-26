using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Queries;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Handlers
{
    public class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<EstructuraOrganizacional>>
    {
        private readonly IEstructuraOrganizacionalRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IEstructuraOrganizacionalRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<EstructuraOrganizacional>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las estructuras organizacionales");
                throw;
            }
        }
    }
}
