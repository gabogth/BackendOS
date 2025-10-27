using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;

namespace nest.core.aplicacion.finanzas.EntidadFinancieras.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<EntidadFinanciera>>, IQueryBase;
}
