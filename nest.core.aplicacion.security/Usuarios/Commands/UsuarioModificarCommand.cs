using MediatR;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Usuarios.Commands
{
    public sealed record UsuarioModificarCommand(
        string Id,
        string Email,
        string Password,
        string PhoneNumber
    ) : IRequest<ApplicationUser>, IUsuarioGenericCommand;
}
