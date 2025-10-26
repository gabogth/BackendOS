using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Handlers
{
    public class OrdenTrabajoDetalleActivoEliminarHandler : IRequestHandler<OrdenTrabajoDetalleActivoEliminarCommand, bool>
    {
        private readonly IOrdenTrabajoDetalleActivoRepository repository;
        private readonly ILogger<OrdenTrabajoDetalleActivoEliminarHandler> logger;

        public OrdenTrabajoDetalleActivoEliminarHandler(IOrdenTrabajoDetalleActivoRepository repository, ILogger<OrdenTrabajoDetalleActivoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(OrdenTrabajoDetalleActivoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar el activo del detalle {DetalleActivoId}", request.Id);
                throw;
            }
        }
    }
}
