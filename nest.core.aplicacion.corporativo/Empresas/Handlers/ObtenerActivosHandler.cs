using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.Empresas.Queries;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.aplicacion.corporativo.Empresas.Handlers
{
    public class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<Empresa>>
    {
        private readonly IEmpresaRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(IEmpresaRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<Empresa>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerActivos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las empresas activas");
                throw;
            }
        }
    }
}
