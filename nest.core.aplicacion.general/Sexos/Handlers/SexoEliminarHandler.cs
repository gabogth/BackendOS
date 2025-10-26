using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Sexos.Commands;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Sexos.Handlers
{
    public class SexoEliminarHandler : IRequestHandler<SexoEliminarCommand, Unit>
    {
        private readonly ISexoRepository repository;
        private readonly ILogger<SexoEliminarHandler> logger;

        public SexoEliminarHandler(ISexoRepository repository, ILogger<SexoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(SexoEliminarCommand request, CancellationToken cancellationToken)
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
