using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceras.Handlers
{
    public class OrdenServicioCabeceraEliminarHandler : IRequestHandler<OrdenServicioCabeceraEliminarCommand, bool>
    {
        private readonly IOrdenServicioCabeceraRepository repository;
        private readonly ILogger<OrdenServicioCabeceraEliminarHandler> logger;

        public OrdenServicioCabeceraEliminarHandler(IOrdenServicioCabeceraRepository repository, ILogger<OrdenServicioCabeceraEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(OrdenServicioCabeceraEliminarCommand request, CancellationToken cancellationToken)
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
