using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.AdjuntoConfigProviders.Commands;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Handlers
{
    public class AdjuntoConfigProviderEliminarHandler : IRequestHandler<AdjuntoConfigProviderEliminarCommand, Unit>
    {
        private readonly IAdjuntoConfigProviderRepository repository;
        private readonly ILogger<AdjuntoConfigProviderEliminarHandler> logger;

        public AdjuntoConfigProviderEliminarHandler(IAdjuntoConfigProviderRepository repository, ILogger<AdjuntoConfigProviderEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(AdjuntoConfigProviderEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
