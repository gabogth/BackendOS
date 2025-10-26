using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.costos.CentroDeCostos.Commands;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.aplicacion.costos.CentroDeCostos.Handlers
{
    internal class CentroDeCostosModificarHandler : IRequestHandler<CentroDeCostosModificarCommand, CentroDeCostos>
    {
        private readonly ICentroDeCostosRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<CentroDeCostosModificarHandler> logger;

        public CentroDeCostosModificarHandler(ICentroDeCostosRepository repository, IMapper mapper, ILogger<CentroDeCostosModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<CentroDeCostos> Handle(CentroDeCostosModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<CentroDeCostos>(request);
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
