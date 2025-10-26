using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Handlers
{
    public class UbicacionTecnicaEliminarHandler : IRequestHandler<UbicacionTecnicaEliminarCommand, bool>
    {
        private readonly IUbicacionTecnicaRepository repository;
        private readonly ILogger<UbicacionTecnicaEliminarHandler> logger;

        public UbicacionTecnicaEliminarHandler(IUbicacionTecnicaRepository repository, ILogger<UbicacionTecnicaEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(UbicacionTecnicaEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar la ubicación técnica {UbicacionTecnicaId}", request.Id);
                throw;
            }
        }
    }
}
