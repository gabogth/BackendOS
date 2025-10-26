using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Handlers
{
    public class OrdenServicioMantenimientoExternoModificarHandler : IRequestHandler<OrdenServicioMantenimientoExternoModificarCommand, OrdenServicioMantenimientoExterno>
    {
        private readonly IOrdenServicioMantenimientoExternoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenServicioMantenimientoExternoModificarCommand> logger;

        public OrdenServicioMantenimientoExternoModificarHandler(IOrdenServicioMantenimientoExternoRepository repository, IMapper mapper, ILogger<OrdenServicioMantenimientoExternoModificarCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenServicioMantenimientoExterno> Handle(OrdenServicioMantenimientoExternoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenServicioMantenimientoExterno>(request);
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
