using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.AdjuntoConfigProviders.Commands;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Handlers
{
    public class AdjuntoConfigProviderCrearHandler : IRequestHandler<AdjuntoConfigProviderCrearCommand, AdjuntoConfigProvider>
    {
        private readonly IAdjuntoConfigProviderRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<AdjuntoConfigProviderCrearHandler> logger;

        public AdjuntoConfigProviderCrearHandler(IAdjuntoConfigProviderRepository repository, IMapper mapper, ILogger<AdjuntoConfigProviderCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<AdjuntoConfigProvider> Handle(AdjuntoConfigProviderCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<AdjuntoConfigProvider>(request);
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
