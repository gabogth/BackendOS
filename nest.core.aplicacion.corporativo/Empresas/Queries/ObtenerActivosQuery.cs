using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.aplicacion.corporativo.Empresas.Queries
{
    public sealed record ObtenerActivosQuery : IRequest<List<Empresa>>, IQueryBase;
}
