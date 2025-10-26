using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Moneda.Commands;
using nest.core.dominio.Finanzas.MonedaEntities;

namespace nest.core.aplicacion.finanzas.Moneda.Handlers
{
    internal class MonedaEliminarHandler : IRequestHandler<MonedaEliminarCommand, bool>
    {
        private readonly IMonedaRepository repository;
        private readonly ILogger<MonedaEliminarHandler> logger;

        public MonedaEliminarHandler(IMonedaRepository repository, ILogger<MonedaEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(MonedaEliminarCommand request, CancellationToken cancellationToken)
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
