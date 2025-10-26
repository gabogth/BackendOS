using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.DocumentoTipos.Commands;
using nest.core.dominio.General.DocumentoTipoEntities;

namespace nest.core.aplicacion.general.DocumentoTipos.Handlers
{
    public sealed class DocumentoTipoCrearHandler : IRequestHandler<DocumentoTipoCrearCommand, DocumentoTipo>
    {
        private readonly IDocumentoTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<DocumentoTipoCrearHandler> logger;

        public DocumentoTipoCrearHandler(
            IDocumentoTipoRepository repository,
            IMapper mapper,
            ILogger<DocumentoTipoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<DocumentoTipo> Handle(DocumentoTipoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<DocumentoTipo>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
