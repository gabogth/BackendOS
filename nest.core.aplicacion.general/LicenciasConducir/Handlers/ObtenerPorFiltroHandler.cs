using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.LicenciasConducir.Queries;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general.LicenciasConducir.Handlers
{
    public class ObtenerPorFiltroHandler : IRequestHandler<ObtenerPorFiltroQuery, LoadResult>
    {
        private readonly ILicenciaConducirRepository repository;
        private readonly ILogger<ObtenerPorFiltroHandler> logger;

        public ObtenerPorFiltroHandler(ILicenciaConducirRepository repository, ILogger<ObtenerPorFiltroHandler> logger)
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
