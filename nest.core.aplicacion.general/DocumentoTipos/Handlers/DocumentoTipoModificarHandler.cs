using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.DocumentoTipos.Commands;
using nest.core.dominio.General.DocumentoTipoEntities;

namespace nest.core.aplicacion.general.DocumentoTipos.Handlers
{
    public sealed class DocumentoTipoModificarHandler : IRequestHandler<DocumentoTipoModificarCommand, DocumentoTipo>
    {
        private readonly IDocumentoTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<DocumentoTipoModificarHandler> logger;

        public DocumentoTipoModificarHandler(
            IDocumentoTipoRepository repository,
            IMapper mapper,
            ILogger<DocumentoTipoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<DocumentoTipo> Handle(DocumentoTipoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<DocumentoTipo>(request);
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
