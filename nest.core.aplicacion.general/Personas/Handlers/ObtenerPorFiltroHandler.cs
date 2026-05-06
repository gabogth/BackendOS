using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Personas.Queries;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Handlers
{
    public class ObtenerPorFiltroHandler : IRequestHandler<ObtenerPorFiltroQuery, LoadResult>
    {
        private readonly IPersonaRepository repository;
        private readonly ILogger<ObtenerPorFiltroHandler> logger;

        public ObtenerPorFiltroHandler(IPersonaRepository repository, ILogger<ObtenerPorFiltroHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<LoadResult> Handle(ObtenerPorFiltroQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await repository.ObtenerTodos();
                return DataSourceLoader.Load(data, request.options);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
