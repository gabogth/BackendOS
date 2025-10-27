using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Commands;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Handlers
{
    public class GrupoTrabajoEliminarHandler : IRequestHandler<GrupoTrabajoEliminarCommand, bool>
    {
        private readonly IGrupoTrabajoRepository repository;
        private readonly ILogger<GrupoTrabajoEliminarHandler> logger;

        public GrupoTrabajoEliminarHandler(IGrupoTrabajoRepository repository, ILogger<GrupoTrabajoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(GrupoTrabajoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar el grupo de trabajo {Id}", request.Id);
                throw;
            }
        }
    }
}
