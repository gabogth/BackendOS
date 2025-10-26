using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.PersonaAdjuntos.Queries;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Handlers
{
    public sealed class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<PersonaAdjunto>>
    {
        private readonly IPersonaAdjuntoRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IPersonaAdjuntoRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<PersonaAdjunto>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
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
