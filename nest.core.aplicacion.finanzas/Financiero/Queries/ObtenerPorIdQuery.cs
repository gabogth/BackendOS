using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;

namespace nest.core.aplicacion.finanzas.Financiero.Queries
{
    public sealed record ObtenerPorIdQuery(
        long Id
    ) : IRequest<FinancieroCabecera>, IQueryBase;
}
