using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Handlers
{
    public sealed class DocumentoIdentidadTipoModificarHandler : IRequestHandler<DocumentoIdentidadTipoModificarCommand, DocumentoIdentidadTipo>
    {
        private readonly IDocumentoIdentidadTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<DocumentoIdentidadTipoModificarHandler> logger;

        public DocumentoIdentidadTipoModificarHandler(
            IDocumentoIdentidadTipoRepository repository,
            IMapper mapper,
            ILogger<DocumentoIdentidadTipoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<DocumentoIdentidadTipo> Handle(DocumentoIdentidadTipoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<DocumentoIdentidadTipo>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
