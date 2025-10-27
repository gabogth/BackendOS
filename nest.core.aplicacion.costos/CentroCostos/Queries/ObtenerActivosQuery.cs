using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.aplicacion.costos.CentroCostos.Queries
{
    public sealed record ObtenerActivosQuery : IRequest<List<CentroDeCostos>>, IQueryBase;
}
