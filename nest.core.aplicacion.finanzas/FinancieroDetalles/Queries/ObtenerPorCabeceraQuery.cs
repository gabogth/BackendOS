using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Queries
{
    public sealed record ObtenerPorCabeceraQuery(
        long FinancieroCabeceraId
    ) : IRequest<List<FinancieroDetalle>>, IQueryBase;
}
