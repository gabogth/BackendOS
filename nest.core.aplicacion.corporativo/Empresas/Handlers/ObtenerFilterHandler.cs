using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.Empresas.Queries;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.aplicacion.corporativo.Empresas.Handlers
{
    public class ObtenerFilterHandler : IRequestHandler<ObtenerFilterQuery, LoadResult>
    {
        private readonly IEmpresaRepository repository;
        private readonly ILogger<ObtenerFilterHandler> logger;

        public ObtenerFilterHandler(IEmpresaRepository repository, ILogger<ObtenerFilterHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<LoadResult> Handle(ObtenerFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerFilter(request.LoadOptions, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener la empresa");
                throw;
            }
        }
    }
}
