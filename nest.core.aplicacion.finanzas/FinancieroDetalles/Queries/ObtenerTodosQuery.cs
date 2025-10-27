using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.aplicacion.finanzas.FinancieroDetalles.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<FinancieroDetalle>>, IQueryBase;
}
