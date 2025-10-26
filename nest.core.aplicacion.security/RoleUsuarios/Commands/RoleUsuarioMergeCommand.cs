using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.security.RoleUsuarios.Commands;

public record RoleUsuarioMergeCommand(
    string RoleName,
    IReadOnlyCollection<string> UsersId
) : IRequest<Unit>, ICommandBase;
