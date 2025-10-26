using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;

namespace nest.core.aplicacion.finanzas.OrigenFinancieros.Queries
{
    public sealed record ObtenerActivosQuery : IRequest<List<OrigenFinanciero>>, IQueryBase;
}
