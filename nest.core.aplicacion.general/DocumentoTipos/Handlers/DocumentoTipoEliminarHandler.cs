using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.DocumentoTipos.Commands;
using nest.core.dominio.General.DocumentoTipoEntities;

namespace nest.core.aplicacion.general.DocumentoTipos.Handlers
{
    public sealed class DocumentoTipoEliminarHandler : IRequestHandler<DocumentoTipoEliminarCommand, bool>
    {
        private readonly IDocumentoTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<DocumentoTipoEliminarHandler> logger;

        public DocumentoTipoEliminarHandler(
            IDocumentoTipoRepository repository,
            IMapper mapper,
            ILogger<DocumentoTipoEliminarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<bool> Handle(DocumentoTipoEliminarCommand request, CancellationToken cancellationToken)
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
