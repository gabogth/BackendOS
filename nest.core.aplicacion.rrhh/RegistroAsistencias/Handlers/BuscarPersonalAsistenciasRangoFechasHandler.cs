using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Queries;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    internal class BuscarPersonalAsistenciasRangoFechasHandler : IRequestHandler<BuscarPersonalAsistenciasRangoFechasQuery, List<Personal>>
    {
        private readonly IRegistroAsistenciaRepository repository;
        private readonly ILogger<BuscarPersonalAsistenciasRangoFechasHandler> logger;

        public BuscarPersonalAsistenciasRangoFechasHandler(IRegistroAsistenciaRepository repository, ILogger<BuscarPersonalAsistenciasRangoFechasHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<Personal>> Handle(BuscarPersonalAsistenciasRangoFechasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await repository.BuscarPersonalAsistenciasRangoFechas(request.FechaInicio, request.FechaFin);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al buscar registros de asistencia.");
                throw;
            }
        }
    }
}
