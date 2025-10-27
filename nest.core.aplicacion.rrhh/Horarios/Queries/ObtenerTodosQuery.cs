using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;

namespace nest.core.aplicacion.rrhh.Horarios.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<HorarioCabecera>>, IQueryBase;
}
