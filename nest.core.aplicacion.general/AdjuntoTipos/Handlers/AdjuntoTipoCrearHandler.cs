using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.AdjuntoTipos.Commands;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.AdjuntoTipos.Handlers
{
    public class AdjuntoTipoCrearHandler : IRequestHandler<AdjuntoTipoCrearCommand, AdjuntoTipo>
    {
        private readonly IAdjuntoTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<AdjuntoTipoCrearHandler> logger;

        public AdjuntoTipoCrearHandler(IAdjuntoTipoRepository repository, IMapper mapper, ILogger<AdjuntoTipoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<AdjuntoTipo> Handle(AdjuntoTipoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<AdjuntoTipo>(request);
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
