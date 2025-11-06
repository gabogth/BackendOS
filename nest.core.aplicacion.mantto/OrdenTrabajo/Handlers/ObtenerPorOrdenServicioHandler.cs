using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajo.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Handlers
{
    internal class ObtenerPorOrdenServicioHandler : IRequestHandler<ObtenerPorOrdenServicioQuery, List<OrdenTrabajoCabecera>>
    {
        private readonly IOrdenTrabajoCabecera_MantenimientoExternoRepository repository;
        private readonly ILogger<ObtenerPorOrdenServicioHandler> logger;

        public ObtenerPorOrdenServicioHandler(IOrdenTrabajoCabecera_MantenimientoExternoRepository repository, ILogger<ObtenerPorOrdenServicioHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoCabecera>> Handle(ObtenerPorOrdenServicioQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorOrdenServicio(request.OrdenServicioCabeceraId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener las órdenes de trabajo de mantenimiento externo para la orden de servicio {OrdenServicioId}", request.OrdenServicioCabeceraId);
                throw;
            }
        }
    }
}
