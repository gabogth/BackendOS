using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;

namespace nest.core.aplicacion.finanzas.EntidadFinanciera.Queries
{
    public sealed record ObtenerPorIdQuery(
        int Id
    ) : IRequest<EntidadFinanciera>, IQueryBase;
}
