using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.PuntoFinancieros.Commands;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;

namespace nest.core.aplicacion.finanzas.PuntoFinancieros.Handlers
{
    public class PuntoFinancieroEliminarHandler : IRequestHandler<PuntoFinancieroEliminarCommand, Unit>
    {
        private readonly IPuntoFinancieroRepository repository;
        private readonly ILogger<PuntoFinancieroEliminarHandler> logger;

        public PuntoFinancieroEliminarHandler(IPuntoFinancieroRepository repository, ILogger<PuntoFinancieroEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(PuntoFinancieroEliminarCommand request, CancellationToken cancellationToken)
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
