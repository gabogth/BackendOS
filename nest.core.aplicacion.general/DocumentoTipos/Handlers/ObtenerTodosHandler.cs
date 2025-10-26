using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.DocumentoTipos.Queries;
using nest.core.dominio.General.DocumentoTipoEntities;

namespace nest.core.aplicacion.general.DocumentoTipos.Handlers
{
    public sealed class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<DocumentoTipo>>
    {
        private readonly IDocumentoTipoRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IDocumentoTipoRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<DocumentoTipo>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
