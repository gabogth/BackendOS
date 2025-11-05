using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicio.Queries;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicio.Handlers
{
    public class ObtenerOrdenServicioMantenimientoExternoTodosHandler
        : IRequestHandler<ObtenerOrdenServicioMantenimientoExternoTodosQuery, List<OrdenServicioCabecera>>
    {
        private readonly IOrdenServicioCabecera_MantenimientoExternoRepository repository;
        private readonly ILogger<ObtenerOrdenServicioMantenimientoExternoTodosHandler> logger;

        public ObtenerOrdenServicioMantenimientoExternoTodosHandler(
            IOrdenServicioCabecera_MantenimientoExternoRepository repository,
            ILogger<ObtenerOrdenServicioMantenimientoExternoTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenServicioCabecera>> Handle(
            ObtenerOrdenServicioMantenimientoExternoTodosQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las órdenes de servicio de mantenimiento externo");
                throw;
            }
        }
    }

    public class ObtenerOrdenServicioMantenimientoExternoPorIdHandler
        : IRequestHandler<ObtenerOrdenServicioMantenimientoExternoPorIdQuery, OrdenServicioCabecera>
    {
        private readonly IOrdenServicioCabecera_MantenimientoExternoRepository repository;
        private readonly ILogger<ObtenerOrdenServicioMantenimientoExternoPorIdHandler> logger;

        public ObtenerOrdenServicioMantenimientoExternoPorIdHandler(
            IOrdenServicioCabecera_MantenimientoExternoRepository repository,
            ILogger<ObtenerOrdenServicioMantenimientoExternoPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<OrdenServicioCabecera> Handle(
            ObtenerOrdenServicioMantenimientoExternoPorIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener la orden de servicio de mantenimiento externo {OrdenServicioId}", request.Id);
                throw;
            }
        }
    }
}
