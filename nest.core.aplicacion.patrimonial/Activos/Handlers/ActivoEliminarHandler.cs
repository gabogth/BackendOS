using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.Activos.Commands;
using nest.core.dominio.Patrimonial.ActivoEntities;

namespace nest.core.aplicacion.patrimonial.Activos.Handlers
{
    public class ActivoEliminarHandler : IRequestHandler<ActivoEliminarCommand, bool>
    {
        private readonly IActivoRepository repository;
        private readonly ILogger<ActivoEliminarHandler> logger;

        public ActivoEliminarHandler(IActivoRepository repository, ILogger<ActivoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(ActivoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar el activo {ActivoId}", request.Id);
                throw;
            }
        }
    }
}
