using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Commands;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Handlers
{
    public class OrdenServicioTipoEliminarHandler : IRequestHandler<OrdenServicioTipoEliminarCommand, bool>
    {
        private readonly IOrdenServicioTipoRepository repository;
        private readonly ILogger<OrdenServicioTipoEliminarHandler> logger;

        public OrdenServicioTipoEliminarHandler(IOrdenServicioTipoRepository repository, ILogger<OrdenServicioTipoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(OrdenServicioTipoEliminarCommand request, CancellationToken cancellationToken)
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
