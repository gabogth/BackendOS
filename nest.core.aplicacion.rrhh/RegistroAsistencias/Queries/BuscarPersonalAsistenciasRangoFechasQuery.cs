using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Queries
{
    public sealed record BuscarPersonalAsistenciasRangoFechasQuery(
        DateTime FechaInicio,
        DateTime FechaFin
    ) : IRequest<List<Personal>>, IQueryBase;
}
