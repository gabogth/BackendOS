using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Queries;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Handlers
{
    public class ObtenerPorActivoHandler : IRequestHandler<ObtenerPorActivoQuery, List<UbicacionActivo>>
    {
        private readonly IUbicacionActivoRepository repository;
        private readonly ILogger<ObtenerPorActivoHandler> logger;

        public ObtenerPorActivoHandler(IUbicacionActivoRepository repository, ILogger<ObtenerPorActivoHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<UbicacionActivo>> Handle(ObtenerPorActivoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorActivo(request.ActivoId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las ubicaciones del activo {ActivoId}", request.ActivoId);
                throw;
            }
        }
    }
}
