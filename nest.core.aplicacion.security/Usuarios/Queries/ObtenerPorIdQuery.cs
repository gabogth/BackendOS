using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Usuarios.Queries
{
    public sealed record ObtenerPorIdQuery(
        string UsuarioId
    ) : IRequest<ApplicationUser?>, IQueryBase;
}
