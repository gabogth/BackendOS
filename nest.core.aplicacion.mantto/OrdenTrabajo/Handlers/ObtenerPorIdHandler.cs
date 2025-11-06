using System;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajo.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoMantenimientoExternoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Handlers
{
    internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, OrdenTrabajoCabecera>
    {
        private readonly IOrdenTrabajoCabecera_MantenimientoExternoRepository repository;
        private readonly ILogger<ObtenerPorIdHandler> logger;

        public ObtenerPorIdHandler(IOrdenTrabajoCabecera_MantenimientoExternoRepository repository, ILogger<ObtenerPorIdHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoCabecera> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorId(request.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener la orden de trabajo de mantenimiento externo {OrdenTrabajoId}", request.Id);
                throw;
            }
        }
    }
}
