using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.security.Usuarios.Commands
{
    public sealed record UsuarioEliminarCommand(
        string UsuarioId
    ) : IRequest<Unit>, ICommandBase;
}
