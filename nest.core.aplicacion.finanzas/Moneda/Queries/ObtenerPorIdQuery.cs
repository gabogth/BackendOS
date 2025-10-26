using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.MonedaEntities;

namespace nest.core.aplicacion.finanzas.Moneda.Queries
{
    public sealed record ObtenerPorIdQuery(
        int Id
    ) : IRequest<Moneda>, IQueryBase;
}
