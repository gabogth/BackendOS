using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.MantenimientoTipos.Commands;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Handlers
{
    public class MantenimientoTipoModificarHandler : IRequestHandler<MantenimientoTipoModificarCommand, MantenimientoTipo>
    {
        private readonly IMantenimientoTipoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<MantenimientoTipoModificarCommand> logger;

        public MantenimientoTipoModificarHandler(IMantenimientoTipoRepository repository, IMapper mapper, ILogger<MantenimientoTipoModificarCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<MantenimientoTipo> Handle(MantenimientoTipoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<MantenimientoTipo>(request);
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
