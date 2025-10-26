using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.DocumentoIdentidadTipos.Commands;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Handlers
{
    public sealed class DocumentoIdentidadTipoEliminarHandler : IRequestHandler<DocumentoIdentidadTipoEliminarCommand, bool>
    {
        private readonly IDocumentoIdentidadTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<DocumentoIdentidadTipoEliminarHandler> logger;

        public DocumentoIdentidadTipoEliminarHandler(
            IDocumentoIdentidadTipoRepository repository,
            IMapper mapper,
            ILogger<DocumentoIdentidadTipoEliminarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<bool> Handle(DocumentoIdentidadTipoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
