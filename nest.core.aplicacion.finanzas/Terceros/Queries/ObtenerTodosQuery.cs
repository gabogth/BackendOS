using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Finanzas.ClienteEntities;

namespace nest.core.aplicacion.finanzas.Terceros.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<Tercero>>, IQueryBase;
}
