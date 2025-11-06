using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<OrdenTrabajoHorario>>, IQueryBase;
}
