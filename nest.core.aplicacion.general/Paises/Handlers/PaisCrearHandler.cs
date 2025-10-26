using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Paises.Commands;
using nest.core.dominio.General.PaisEntities;

namespace nest.core.aplicacion.general.Paises.Handlers
{
    public class PaisCrearHandler : IRequestHandler<PaisCrearCommand, Pais>
    {
        private readonly IPaisRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<PaisCrearHandler> logger;

        public PaisCrearHandler(IPaisRepository repository, IMapper mapper, ILogger<PaisCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Pais> Handle(PaisCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Pais>(request);
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
