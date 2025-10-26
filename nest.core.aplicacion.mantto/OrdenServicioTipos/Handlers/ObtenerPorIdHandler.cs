using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Queries;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioTipos.Handlers
{
    public class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, OrdenServicioTipo>
    {
        private readonly IOrdenServicioTipoRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IOrdenServicioTipoRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<OrdenServicioTipo> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
