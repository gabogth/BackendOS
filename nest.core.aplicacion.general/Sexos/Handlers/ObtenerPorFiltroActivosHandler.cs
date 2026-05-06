using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Sexos.Queries;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Sexos.Handlers
{
    public class ObtenerPorFiltroActivosHandler : IRequestHandler<ObtenerPorFiltroActivosQuery, LoadResult>
    {
        private readonly ISexoRepository repository;
        private readonly ILogger<ObtenerPorFiltroActivosHandler> logger;

        public ObtenerPorFiltroActivosHandler(ISexoRepository repository, ILogger<ObtenerPorFiltroActivosHandler> logger)
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
