using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Handlers
{
    public class OrdenServicioMantenimientoExternoEliminarHandler : IRequestHandler<OrdenServicioMantenimientoExternoEliminarCommand, bool>
    {
        private readonly IOrdenServicioMantenimientoExternoRepository repository;
        private readonly ILogger<OrdenServicioMantenimientoExternoEliminarHandler> logger;

        public OrdenServicioMantenimientoExternoEliminarHandler(IOrdenServicioMantenimientoExternoRepository repository, ILogger<OrdenServicioMantenimientoExternoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(OrdenServicioMantenimientoExternoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
