using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.Activos.Queries;
using nest.core.dominio.Patrimonial.ActivoEntities;

namespace nest.core.aplicacion.patrimonial.Activos.Handlers
{
    public class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<Activo>>
    {
        private readonly IActivoRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(IActivoRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<Activo>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerActivos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los activos habilitados");
                throw;
            }
        }
    }
}
