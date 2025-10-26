using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Personas.Queries;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Handlers
{
    internal class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<Persona>>
    {
        private readonly IPersonaRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;
        public ObtenerTodosHandler(IPersonaRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public async Task<List<Persona>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
