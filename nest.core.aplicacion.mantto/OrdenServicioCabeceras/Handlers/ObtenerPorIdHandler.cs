using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Queries;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceras.Handlers
{
    public class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, OrdenServicioCabecera>
    {
        private readonly IOrdenServicioCabeceraRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IOrdenServicioCabeceraRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<OrdenServicioCabecera> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
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
