using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Monedas.Commands;
using nest.core.dominio.Finanzas.MonedaEntities;

namespace nest.core.aplicacion.finanzas.Monedas.Handlers
{
    internal class MonedaCrearHandler : IRequestHandler<MonedaCrearCommand, Moneda>
    {
        private readonly IMonedaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<MonedaCrearHandler> logger;

        public MonedaCrearHandler(IMonedaRepository repository, IMapper mapper, ILogger<MonedaCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Moneda> Handle(MonedaCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Moneda>(request);
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
