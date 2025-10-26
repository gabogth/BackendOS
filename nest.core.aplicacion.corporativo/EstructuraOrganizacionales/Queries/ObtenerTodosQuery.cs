using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<EstructuraOrganizacional>>, IQueryBase;
}
