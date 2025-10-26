using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Handlers
{
    public class OrdenTrabajoCabeceraEliminarHandler : IRequestHandler<OrdenTrabajoCabeceraEliminarCommand, bool>
    {
        private readonly IOrdenTrabajoCabeceraRepository repository;
        private readonly ILogger<OrdenTrabajoCabeceraEliminarHandler> logger;

        public OrdenTrabajoCabeceraEliminarHandler(IOrdenTrabajoCabeceraRepository repository, ILogger<OrdenTrabajoCabeceraEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(OrdenTrabajoCabeceraEliminarCommand request, CancellationToken cancellationToken)
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
