using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.Empresas.Queries;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.aplicacion.corporativo.Empresas.Handlers
{
    public class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, Empresa?>
    {
        private readonly IEmpresaRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IEmpresaRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Empresa?> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener la empresa");
                throw;
            }
        }
    }
}
