using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.MantenimientoTipos.Commands;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Handlers
{
    public class MantenimientoTipoCrearHandler : IRequestHandler<MantenimientoTipoCrearCommand, MantenimientoTipo>
    {
        private readonly IMantenimientoTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<MantenimientoTipoCrearCommand> logger;

        public MantenimientoTipoCrearHandler(IMantenimientoTipoRepository repository, IMapper mapper, ILogger<MantenimientoTipoCrearCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<MantenimientoTipo> Handle(MantenimientoTipoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<MantenimientoTipo>(request);
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
