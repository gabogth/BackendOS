using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Queries;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Handlers
{
    public class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, OrdenServicioMantenimientoExterno>
    {
        private readonly IOrdenServicioMantenimientoExternoRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IOrdenServicioMantenimientoExternoRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<OrdenServicioMantenimientoExterno> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
