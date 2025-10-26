using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Commands;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Handlers
{
    public class UbicacionActivoEliminarHandler : IRequestHandler<UbicacionActivoEliminarCommand, bool>
    {
        private readonly IUbicacionActivoRepository repository;
        private readonly ILogger<UbicacionActivoEliminarHandler> logger;

        public UbicacionActivoEliminarHandler(IUbicacionActivoRepository repository, ILogger<UbicacionActivoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(UbicacionActivoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar la ubicación del activo {UbicacionActivoId}", request.Id);
                throw;
            }
        }
    }
}
