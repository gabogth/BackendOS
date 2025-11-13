using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    internal class BuscarPorPersonalIdRangoFechaHandler : IRequestHandler<BuscarPorPersonalIdRangoFechaQuery, List<RegistroAsistencia>>
    {
        private readonly IRegistroAsistenciaRepository repository;
        private readonly ILogger<BuscarPorPersonalIdRangoFechaHandler> logger;

        public BuscarPorPersonalIdRangoFechaHandler(IRegistroAsistenciaRepository repository, ILogger<BuscarPorPersonalIdRangoFechaHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<RegistroAsistencia>> Handle(BuscarPorPersonalIdRangoFechaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.BuscarPorRangoFecha(request.PersonalId, request.FechaInicio, request.FechaFin);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al buscar registros de asistencia para el personal {PersonalId}", request.PersonalId);
                throw;
            }
        }
    }
}
