using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Distritos.Commands;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Distritos.Handlers
{
    public class DistritoEliminarHandler : IRequestHandler<DistritoEliminarCommand, bool>
    {
        private readonly IDistritoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<DistritoEliminarHandler> logger;
        public DistritoEliminarHandler(IDistritoRepository repository, IMapper mapper, ILogger<DistritoEliminarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<bool> Handle(DistritoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
