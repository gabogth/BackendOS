using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Queries;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Handlers
{
    internal class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<GrupoTrabajo>>
    {
        private readonly IGrupoTrabajoRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IGrupoTrabajoRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<GrupoTrabajo>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los grupos de trabajo");
                throw;
            }
        }
    }
}
