using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Queries
{
    public sealed record ObtenerPorIdQuery(
        int Id
    ) : IRequest<EstructuraOrganizacional?>, IQueryBase;
}
