using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.Labores.Commands;
using nest.core.dominio.Mantto.LaborEntities;

namespace nest.core.aplicacion.mantto.Labores.Handlers
{
    public class LaborEliminarHandler : IRequestHandler<LaborEliminarCommand, Unit>
    {
        private readonly ILaborRepository repository;
        private readonly ILogger<LaborEliminarHandler> logger;

        public LaborEliminarHandler(ILaborRepository repository, ILogger<LaborEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(LaborEliminarCommand request, CancellationToken cancellationToken)
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
