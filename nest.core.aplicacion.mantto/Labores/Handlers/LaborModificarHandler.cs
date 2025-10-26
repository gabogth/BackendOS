using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.Labores.Commands;
using nest.core.dominio.Mantto.LaborEntities;

namespace nest.core.aplicacion.mantto.Labores.Handlers
{
    public class LaborModificarHandler : IRequestHandler<LaborModificarCommand, Labor>
    {
        private readonly ILaborRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<LaborModificarHandler> logger;

        public LaborModificarHandler(ILaborRepository repository, IMapper mapper, ILogger<LaborModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Labor> Handle(LaborModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Labor>(request);
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
