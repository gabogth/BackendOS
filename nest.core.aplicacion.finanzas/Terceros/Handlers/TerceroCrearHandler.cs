using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.finanzas.Terceros.Commands;
using nest.core.dominio.Finanzas.ClienteEntities;

namespace nest.core.aplicacion.finanzas.Terceros.Handlers
{
    public class TerceroCrearHandler : IRequestHandler<TerceroCrearCommand, Tercero>
    {
        private readonly ITerceroRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<TerceroCrearHandler> logger;

        public TerceroCrearHandler(ITerceroRepository repository, IMapper mapper, ILogger<TerceroCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Tercero> Handle(TerceroCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Tercero>(request);
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
