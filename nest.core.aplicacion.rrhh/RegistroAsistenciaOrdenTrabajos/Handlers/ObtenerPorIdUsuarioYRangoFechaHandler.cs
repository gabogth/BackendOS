using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;
using nest.core.dominio.Security.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Handlers
{
    internal class ObtenerPorIdUsuarioYRangoFechaHandler : IRequestHandler<ObtenerPorIIdUsuarioYRangoFechaQuery, List<RegistroAsistencia>>
    {
        private readonly IRegistroAsistencia_OrdenTrabajoRepository repository;
        
        private readonly ILogger<ObtenerTodosHandler> logger;
        

        public ObtenerPorIdUsuarioYRangoFechaHandler(IRegistroAsistencia_OrdenTrabajoRepository repository, ILogger<ObtenerTodosHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<RegistroAsistencia>> Handle(ObtenerPorIIdUsuarioYRangoFechaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.ObtenerPorIdUsuarioYRangoFecha(request.UsuarioId, request.fechaInicio, request.fechaFin);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los registros de asistencia");
                throw;
            }
        }
    }
}
