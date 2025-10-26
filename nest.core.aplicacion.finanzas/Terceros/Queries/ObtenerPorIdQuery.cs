using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.ClienteEntities;

namespace nest.core.aplicacion.finanzas.Terceros.Queries
{
    public sealed record ObtenerPorIdQuery(
        int Id
    ) : IRequest<Tercero>, IQueryBase;
}
