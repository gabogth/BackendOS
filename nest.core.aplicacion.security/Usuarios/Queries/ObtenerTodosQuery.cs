using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Usuarios.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<ApplicationUser>>, IQueryBase;
}
