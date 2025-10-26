using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.aplicacion.costos.CentroDeCostos.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<CentroDeCostos>>, IQueryBase;
}
