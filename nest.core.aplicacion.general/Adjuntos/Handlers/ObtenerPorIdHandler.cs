using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Adjuntos.Queries;
using nest.core.dominio.General.AdjuntoEntities;

namespace nest.core.aplicacion.general.Adjuntos.Handlers
{
    internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, Adjunto>
    {
        private readonly IAdjuntoRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IAdjuntoRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Adjunto> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
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
