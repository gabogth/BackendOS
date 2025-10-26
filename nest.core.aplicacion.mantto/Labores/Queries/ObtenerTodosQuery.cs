using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.LaborEntities;

namespace nest.core.aplicacion.mantto.Labores.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<Labor>>, IQueryBase;
}
