using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.costos.CentroDeCostos.Commands;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.aplicacion.costos.CentroDeCostos.Handlers
{
    internal class CentroDeCostosEliminarHandler : IRequestHandler<CentroDeCostosEliminarCommand, bool>
    {
        private readonly ICentroDeCostosRepository repository;
        private readonly ILogger<CentroDeCostosEliminarHandler> logger;

        public CentroDeCostosEliminarHandler(ICentroDeCostosRepository repository, ILogger<CentroDeCostosEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(CentroDeCostosEliminarCommand request, CancellationToken cancellationToken)
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
