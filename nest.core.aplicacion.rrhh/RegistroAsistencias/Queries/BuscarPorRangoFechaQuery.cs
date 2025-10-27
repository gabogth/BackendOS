using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Queries
{
    public sealed record BuscarPorRangoFechaQuery(
        int PersonalId,
        DateTime FechaInicio,
        DateTime FechaFin
    ) : IRequest<List<RegistroAsistencia>>, IQueryBase;
}
