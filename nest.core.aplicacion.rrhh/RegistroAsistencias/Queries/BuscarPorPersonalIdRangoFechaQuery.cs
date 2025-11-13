using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Queries
{
    public sealed record BuscarPorPersonalIdRangoFechaQuery(
        int PersonalId,
        DateTime FechaInicio,
        DateTime FechaFin
    ) : IRequest<List<RegistroAsistencia>>, IQueryBase;
}
