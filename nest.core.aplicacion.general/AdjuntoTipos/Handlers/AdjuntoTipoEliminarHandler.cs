using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.AdjuntoTipos.Commands;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.AdjuntoTipos.Handlers
{
    public class AdjuntoTipoEliminarHandler : IRequestHandler<AdjuntoTipoEliminarCommand, Unit>
    {
        private readonly IAdjuntoTipoRepository repository;
        private readonly ILogger<AdjuntoTipoEliminarHandler> logger;

        public AdjuntoTipoEliminarHandler(IAdjuntoTipoRepository repository, ILogger<AdjuntoTipoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(AdjuntoTipoEliminarCommand request, CancellationToken cancellationToken)
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
