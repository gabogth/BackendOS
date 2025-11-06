using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Handlers
{
    internal class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<OrdenTrabajoPersonal>>
    {
        private readonly IOrdenTrabajoPersonalRepository repository;
        private readonly ILogger<ObtenerTodosHandler> logger;

        public ObtenerTodosHandler(IOrdenTrabajoPersonalRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<OrdenTrabajoPersonal>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener el listado de personal asignado a órdenes de trabajo");
                throw;
            }
        }
    }
}
