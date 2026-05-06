using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Personas.Queries;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Handlers
{
    public class ObtenerPorFiltroActivosHandler : IRequestHandler<ObtenerPorFiltroActivosQuery, LoadResult>
    {
        private readonly IPersonaRepository repository;
        private readonly ILogger<ObtenerPorFiltroActivosHandler> logger;

        public ObtenerPorFiltroActivosHandler(IPersonaRepository repository, ILogger<ObtenerPorFiltroActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<LoadResult> Handle(ObtenerPorFiltroActivosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await repository.ObtenerActivos();
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
