using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Usuarios.Commands
{
    public sealed record UsuarioModificarCommand(
        ApplicationUser Usuario
    ) : IRequest<ApplicationUser>, ICommandBase;
}
