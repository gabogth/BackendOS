using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;

namespace nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Queries
{
    public sealed record ObtenerActivosQuery : IRequest<List<EstructuraOrganizacionalTipo>>, IQueryBase;
}
