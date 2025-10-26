using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.patrimonial.UbicacionTecnicas.Queries;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionTecnicas.Handlers
{
    public class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<UbicacionTecnica>>
    {
        private readonly IUbicacionTecnicaRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IUbicacionTecnicaRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<UbicacionTecnica>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las ubicaciones técnicas");
                throw;
            }
        }
    }
}
