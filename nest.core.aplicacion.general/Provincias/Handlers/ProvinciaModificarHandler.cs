using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Provincias.Commands;
using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.aplicacion.general.Provincias.Handlers
{
    public class ProvinciaModificarHandler : IRequestHandler<ProvinciaModificarCommand, Provincia>
    {
        private readonly IProvinciaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<ProvinciaModificarHandler> logger;

        public ProvinciaModificarHandler(IProvinciaRepository repository, IMapper mapper, ILogger<ProvinciaModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Provincia> Handle(ProvinciaModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Provincia>(request);
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
