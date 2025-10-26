using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;

namespace nest.core.aplicacion.finanzas.PuntoFinancieros.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<PuntoFinanciero>>, IQueryBase;
}
