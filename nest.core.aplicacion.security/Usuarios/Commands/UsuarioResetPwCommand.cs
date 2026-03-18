using MediatR;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Usuarios.Commands
{
    public sealed record UsuarioResetPwCommand(
        string Id,
        string Password
    ) : IRequest<ApplicationUser>;
}
