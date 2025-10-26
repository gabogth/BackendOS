using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Handlers
{
    public class OrdenTrabajoDetalleEliminarHandler : IRequestHandler<OrdenTrabajoDetalleEliminarCommand, bool>
    {
        private readonly IOrdenTrabajoDetalleRepository repository;
        private readonly ILogger<OrdenTrabajoDetalleEliminarHandler> logger;

        public OrdenTrabajoDetalleEliminarHandler(IOrdenTrabajoDetalleRepository repository, ILogger<OrdenTrabajoDetalleEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(OrdenTrabajoDetalleEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar el detalle {DetalleId}", request.Id);
                throw;
            }
        }
    }
}
