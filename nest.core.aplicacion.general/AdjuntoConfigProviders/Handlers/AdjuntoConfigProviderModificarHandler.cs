using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.AdjuntoConfigProviders.Commands;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.AdjuntoConfigProviders.Handlers
{
    public class AdjuntoConfigProviderModificarHandler : IRequestHandler<AdjuntoConfigProviderModificarCommand, AdjuntoConfigProvider>
    {
        private readonly IAdjuntoConfigProviderRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<AdjuntoConfigProviderModificarHandler> logger;

        public AdjuntoConfigProviderModificarHandler(IAdjuntoConfigProviderRepository repository, IMapper mapper, ILogger<AdjuntoConfigProviderModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<AdjuntoConfigProvider> Handle(AdjuntoConfigProviderModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<AdjuntoConfigProvider>(request);
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
