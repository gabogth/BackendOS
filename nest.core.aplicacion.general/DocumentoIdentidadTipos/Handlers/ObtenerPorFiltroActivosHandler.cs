using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.DocumentoIdentidadTipos.Queries;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Handlers
{
    public class ObtenerPorFiltroActivosHandler : IRequestHandler<ObtenerPorFiltroActivosQuery, LoadResult>
    {
        private readonly IDocumentoIdentidadTipoRepository repository;
        private readonly ILogger<ObtenerPorFiltroActivosHandler> logger;

        public ObtenerPorFiltroActivosHandler(IDocumentoIdentidadTipoRepository repository, ILogger<ObtenerPorFiltroActivosHandler> logger)
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
