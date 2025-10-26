using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Personas.Queries;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Handlers
{
    internal class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<Persona>>
    {
        private readonly IPersonaRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;
        public ObtenerActivosHandler(IPersonaRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public async Task<List<Persona>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
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
