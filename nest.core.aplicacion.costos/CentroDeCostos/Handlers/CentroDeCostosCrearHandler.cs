using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.costos.CentroDeCostos.Commands;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.aplicacion.costos.CentroDeCostos.Handlers
{
    internal class CentroDeCostosCrearHandler : IRequestHandler<CentroDeCostosCrearCommand, CentroDeCostos>
    {
        private readonly ICentroDeCostosRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<CentroDeCostosCrearHandler> logger;

        public CentroDeCostosCrearHandler(ICentroDeCostosRepository repository, IMapper mapper, ILogger<CentroDeCostosCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<CentroDeCostos> Handle(CentroDeCostosCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<CentroDeCostos>(request);
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
