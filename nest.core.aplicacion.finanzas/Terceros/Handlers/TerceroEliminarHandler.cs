using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Terceros.Commands;
using nest.core.dominio.Finanzas.ClienteEntities;

namespace nest.core.aplicacion.finanzas.Terceros.Handlers
{
    public class TerceroEliminarHandler : IRequestHandler<TerceroEliminarCommand, Unit>
    {
        private readonly ITerceroRepository repository;
        private readonly ILogger<TerceroEliminarHandler> logger;

        public TerceroEliminarHandler(ITerceroRepository repository, ILogger<TerceroEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(TerceroEliminarCommand request, CancellationToken cancellationToken)
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
