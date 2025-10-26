using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Handlers
{
    public class OrdenServicioMantenimientoExternoCrearHandler : IRequestHandler<OrdenServicioMantenimientoExternoCrearCommand, OrdenServicioMantenimientoExterno>
    {
        private readonly IOrdenServicioMantenimientoExternoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenServicioMantenimientoExternoCrearCommand> logger;

        public OrdenServicioMantenimientoExternoCrearHandler(IOrdenServicioMantenimientoExternoRepository repository, IMapper mapper, ILogger<OrdenServicioMantenimientoExternoCrearCommand> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenServicioMantenimientoExterno> Handle(OrdenServicioMantenimientoExternoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<OrdenServicioMantenimientoExterno>(request);
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
