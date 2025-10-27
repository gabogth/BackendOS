using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Queries
{
    public sealed record ObtenerPorIdQuery(
        long Id
    ) : IRequest<UsuarioEmpresa?>, IQueryBase;
}
