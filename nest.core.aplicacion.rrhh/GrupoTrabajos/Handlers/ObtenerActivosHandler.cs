using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Queries;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Handlers
{
    internal class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<GrupoTrabajo>>
    {
        private readonly IGrupoTrabajoRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(IGrupoTrabajoRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<GrupoTrabajo>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerActivos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los grupos de trabajo activos");
                throw;
            }
        }
    }
}
