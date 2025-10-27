using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Usuarios.Commands
{
    public sealed record UsuarioCrearCommand(
        ApplicationUser Usuario,
        string Password
    ) : IRequest<ApplicationUser>, ICommandBase;
}
