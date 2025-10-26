using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.PaisEntities;

namespace nest.core.aplicacion.general.Paises.Queries
{
    public sealed record ObtenerActivosQuery : IRequest<List<Pais>>, IQueryBase;
}
