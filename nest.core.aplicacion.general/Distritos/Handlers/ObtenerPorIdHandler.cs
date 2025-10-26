using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Distritos.Queries;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Distritos.Handlers
{
    public class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, Distrito>
    {
        private readonly IDistritoRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;
        public ObtenerPorIdHandler(IDistritoRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public async Task<Distrito> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
