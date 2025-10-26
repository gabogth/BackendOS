using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.DocumentoTipos.Queries;
using nest.core.dominio.General.DocumentoTipoEntities;

namespace nest.core.aplicacion.general.DocumentoTipos.Handlers
{
    public sealed class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, DocumentoTipo>
    {
        private readonly IDocumentoTipoRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IDocumentoTipoRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<DocumentoTipo> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
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
