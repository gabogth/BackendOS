using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.MonedaEntities;

namespace nest.core.aplicacion.finanzas.Monedas.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<Moneda>>, IQueryBase;
}
