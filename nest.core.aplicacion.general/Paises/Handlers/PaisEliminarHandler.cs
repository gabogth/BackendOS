using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Paises.Commands;
using nest.core.dominio.General.PaisEntities;

namespace nest.core.aplicacion.general.Paises.Handlers
{
    public class PaisEliminarHandler : IRequestHandler<PaisEliminarCommand, Unit>
    {
        private readonly IPaisRepository repository;
        private readonly ILogger<PaisEliminarHandler> logger;

        public PaisEliminarHandler(IPaisRepository repository, ILogger<PaisEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(PaisEliminarCommand request, CancellationToken cancellationToken)
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
