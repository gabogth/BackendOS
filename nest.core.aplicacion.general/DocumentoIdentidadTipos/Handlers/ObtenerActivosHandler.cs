using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.DocumentoIdentidadTipos.Queries;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Handlers
{
    public sealed class ObtenerActivosHandler : IRequestHandler<ObtenerActivosQuery, List<DocumentoIdentidadTipo>>
    {
        private readonly IDocumentoIdentidadTipoRepository repository;
        private readonly ILogger<ObtenerActivosHandler> logger;

        public ObtenerActivosHandler(IDocumentoIdentidadTipoRepository repository, ILogger<ObtenerActivosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<DocumentoIdentidadTipo>> Handle(ObtenerActivosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerActivos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
