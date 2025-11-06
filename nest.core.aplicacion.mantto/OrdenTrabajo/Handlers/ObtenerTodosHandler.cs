using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajo.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Handlers
{
    internal class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<OrdenTrabajoCabecera>>
    {
        private readonly IOrdenTrabajoCabecera_MantenimientoExternoRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IOrdenTrabajoCabecera_MantenimientoExternoRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoCabecera>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
