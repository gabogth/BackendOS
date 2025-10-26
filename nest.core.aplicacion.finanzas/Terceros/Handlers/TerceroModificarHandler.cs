using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Terceros.Commands;
using nest.core.dominio.Finanzas.ClienteEntities;

namespace nest.core.aplicacion.finanzas.Terceros.Handlers
{
    public class TerceroModificarHandler : IRequestHandler<TerceroModificarCommand, Tercero>
    {
        private readonly ITerceroRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<TerceroModificarHandler> logger;

        public TerceroModificarHandler(ITerceroRepository repository, IMapper mapper, ILogger<TerceroModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Tercero> Handle(TerceroModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Tercero>(request);
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
