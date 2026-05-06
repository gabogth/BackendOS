using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.AdjuntoTipos.Queries;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.AdjuntoTipos.Handlers
{
    public class ObtenerPorFiltroHandler : IRequestHandler<ObtenerPorFiltroQuery, LoadResult>
    {
        private readonly IAdjuntoTipoRepository repository;
        private readonly ILogger<ObtenerPorFiltroHandler> logger;

        public ObtenerPorFiltroHandler(IAdjuntoTipoRepository repository, ILogger<ObtenerPorFiltroHandler> logger)
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
