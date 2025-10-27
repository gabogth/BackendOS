using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Horarios.Queries;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;

namespace nest.core.aplicacion.rrhh.Horarios.Handlers
{
    internal class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<HorarioCabecera>>
    {
        private readonly IHorarioRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IHorarioRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<HorarioCabecera>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los horarios");
                throw;
            }
        }
    }
}
