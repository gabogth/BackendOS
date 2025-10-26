using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Handlers
{
    public class OrdenTrabajoPersonalEliminarHandler : IRequestHandler<OrdenTrabajoPersonalEliminarCommand, bool>
    {
        private readonly IOrdenTrabajoPersonalRepository repository;
        private readonly ILogger<OrdenTrabajoPersonalEliminarHandler> logger;

        public OrdenTrabajoPersonalEliminarHandler(IOrdenTrabajoPersonalRepository repository, ILogger<OrdenTrabajoPersonalEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(OrdenTrabajoPersonalEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar el personal asignado {PersonalId}", request.Id);
                throw;
            }
        }
    }
}
