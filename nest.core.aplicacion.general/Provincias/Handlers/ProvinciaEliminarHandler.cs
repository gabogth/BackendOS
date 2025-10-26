using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Provincias.Commands;
using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.aplicacion.general.Provincias.Handlers
{
    public class ProvinciaEliminarHandler : IRequestHandler<ProvinciaEliminarCommand, Unit>
    {
        private readonly IProvinciaRepository repository;
        private readonly ILogger<ProvinciaEliminarHandler> logger;

        public ProvinciaEliminarHandler(IProvinciaRepository repository, ILogger<ProvinciaEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Unit> Handle(ProvinciaEliminarCommand request, CancellationToken cancellationToken)
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
