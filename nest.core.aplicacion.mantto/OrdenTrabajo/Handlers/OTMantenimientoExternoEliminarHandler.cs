using System;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoMantenimientoExternoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Handlers
{
    public class OTMantenimientoExternoEliminarHandler : IRequestHandler<OTMantenimientoExternoEliminarCommand, bool>
    {
        private readonly IOrdenTrabajoCabecera_MantenimientoExternoRepository repository;
        private readonly ILogger<OTMantenimientoExternoEliminarHandler> logger;

        public OTMantenimientoExternoEliminarHandler(
            IOrdenTrabajoCabecera_MantenimientoExternoRepository repository,
            ILogger<OTMantenimientoExternoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(OTMantenimientoExternoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar la orden de trabajo de mantenimiento externo {OrdenTrabajoId}", request.Id);
                throw;
            }
        }
    }
}
