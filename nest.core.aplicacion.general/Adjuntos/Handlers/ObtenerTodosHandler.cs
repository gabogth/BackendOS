using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Adjuntos.Queries;
using nest.core.dominio.General.AdjuntoEntities;

namespace nest.core.aplicacion.general.Adjuntos.Handlers
{
    internal class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<Adjunto>>
    {
        private readonly IAdjuntoRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IAdjuntoRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<Adjunto>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
