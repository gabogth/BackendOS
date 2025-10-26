using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Personas.Queries;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Handlers
{
    public class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, Persona>
    {
        private readonly IPersonaRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;
        public ObtenerPorIdHandler(IPersonaRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public async Task<Persona> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
