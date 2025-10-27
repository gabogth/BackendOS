using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.FinancieroCabeceras.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<FinancieroCabecera>>, IQueryBase;
}
