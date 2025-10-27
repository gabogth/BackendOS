using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    internal class BuscarPorRangoFechaHandler : IRequestHandler<BuscarPorRangoFechaQuery, List<RegistroAsistencia>>
    {
        private readonly IRegistroAsistenciaRepository repository;
        private readonly ILogger<BuscarPorRangoFechaHandler> logger;

        public BuscarPorRangoFechaHandler(IRegistroAsistenciaRepository repository, ILogger<BuscarPorRangoFechaHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<RegistroAsistencia>> Handle(BuscarPorRangoFechaQuery request, CancellationToken cancellationToken)
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
