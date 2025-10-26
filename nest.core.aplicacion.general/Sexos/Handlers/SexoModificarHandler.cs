using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Sexos.Commands;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Sexos.Handlers
{
    public class SexoModificarHandler : IRequestHandler<SexoModificarCommand, Sexo>
    {
        private readonly ISexoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<SexoModificarHandler> logger;

        public SexoModificarHandler(ISexoRepository repository, IMapper mapper, ILogger<SexoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Sexo> Handle(SexoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Sexo>(request);
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
