using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Monedas.Commands;
using nest.core.dominio.Finanzas.MonedaEntities;

namespace nest.core.aplicacion.finanzas.Monedas.Handlers
{
    internal class MonedaModificarHandler : IRequestHandler<MonedaModificarCommand, Moneda>
    {
        private readonly IMonedaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<MonedaModificarHandler> logger;

        public MonedaModificarHandler(IMonedaRepository repository, IMapper mapper, ILogger<MonedaModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Moneda> Handle(MonedaModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Moneda>(request);
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
