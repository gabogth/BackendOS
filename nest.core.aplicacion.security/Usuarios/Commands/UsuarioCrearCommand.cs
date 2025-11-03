using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Usuarios.Commands
{
    public sealed record UsuarioCrearCommand(
        string Email,
        string Password,
        string PhoneNumber
    ) : IRequest<ApplicationUser>, IUsuarioGenericCommand;
}
