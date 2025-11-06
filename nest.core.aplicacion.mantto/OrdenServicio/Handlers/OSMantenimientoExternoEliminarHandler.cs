
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicio.Commands;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicio.Handlers
{
    public class OSMantenimientoExternoEliminarHandler : IRequestHandler<OSMantenimientoExternoEliminarCommand, bool>
    {
        private readonly IOrdenServicioCabeceraRepository repository;
        private readonly ILogger<OSMantenimientoExternoEliminarHandler> logger;

        public OSMantenimientoExternoEliminarHandler(IOrdenServicioCabeceraRepository repository,
            ILogger<OSMantenimientoExternoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(OSMantenimientoExternoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar la orden de servicio de mantenimiento externo {OrdenServicioId}", request.Id);
                throw;
            }
        }
    }
}
