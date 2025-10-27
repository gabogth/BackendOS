using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<GrupoTrabajo>>, IQueryBase;
}
