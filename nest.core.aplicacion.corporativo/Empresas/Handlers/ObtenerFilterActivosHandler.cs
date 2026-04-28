using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.Empresas.Queries;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.aplicacion.corporativo.Empresas.Handlers
{
    public class ObtenerFilterActivosHandler : IRequestHandler<ObtenerFilterActivosQuery, LoadResult>
    {
        private readonly IEmpresaRepository repository;
        private readonly ILogger<ObtenerFilterActivosHandler> logger;

        public ObtenerFilterActivosHandler(IEmpresaRepository repository, ILogger<ObtenerFilterActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<LoadResult> Handle(ObtenerFilterActivosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerFilterActivos(request.LoadOptions, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener la empresa");
                throw;
            }
        }
    }
}
