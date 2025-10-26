using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Handlers
{
    public sealed class DocumentoIdentidadTipoCrearHandler : IRequestHandler<DocumentoIdentidadTipoCrearCommand, DocumentoIdentidadTipo>
    {
        private readonly IDocumentoIdentidadTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<DocumentoIdentidadTipoCrearHandler> logger;

        public DocumentoIdentidadTipoCrearHandler(
            IDocumentoIdentidadTipoRepository repository,
            IMapper mapper,
            ILogger<DocumentoIdentidadTipoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<DocumentoIdentidadTipo> Handle(DocumentoIdentidadTipoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<DocumentoIdentidadTipo>(request);
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
