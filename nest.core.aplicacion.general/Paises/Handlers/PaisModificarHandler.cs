using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Paises.Commands;
using nest.core.dominio.General.PaisEntities;

namespace nest.core.aplicacion.general.Paises.Handlers
{
    public class PaisModificarHandler : IRequestHandler<PaisModificarCommand, Pais>
    {
        private readonly IPaisRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<PaisModificarHandler> logger;

        public PaisModificarHandler(IPaisRepository repository, IMapper mapper, ILogger<PaisModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Pais> Handle(PaisModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Pais>(request);
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
