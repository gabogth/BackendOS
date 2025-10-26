using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Provincias.Commands;
using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.aplicacion.general.Provincias.Handlers
{
    public class ProvinciaCrearHandler : IRequestHandler<ProvinciaCrearCommand, Provincia>
    {
        private readonly IProvinciaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<ProvinciaCrearHandler> logger;

        public ProvinciaCrearHandler(IProvinciaRepository repository, IMapper mapper, ILogger<ProvinciaCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Provincia> Handle(ProvinciaCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Provincia>(request);
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
