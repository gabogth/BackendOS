using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.Labores.Commands;
using nest.core.dominio.Mantto.LaborEntities;

namespace nest.core.aplicacion.mantto.Labores.Handlers
{
    public class LaborCrearHandler : IRequestHandler<LaborCrearCommand, Labor>
    {
        private readonly ILaborRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<LaborCrearHandler> logger;

        public LaborCrearHandler(ILaborRepository repository, IMapper mapper, ILogger<LaborCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Labor> Handle(LaborCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Labor>(request);
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
