using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Sexos.Commands;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Sexos.Handlers
{
    public class SexoCrearHandler : IRequestHandler<SexoCrearCommand, Sexo>
    {
        private readonly ISexoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<SexoCrearHandler> logger;

        public SexoCrearHandler(ISexoRepository repository, IMapper mapper, ILogger<SexoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Sexo> Handle(SexoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Sexo>(request);
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
