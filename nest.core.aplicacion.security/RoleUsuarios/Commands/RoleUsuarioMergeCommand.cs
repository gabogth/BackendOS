using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.security.RoleUsuarios.Commands;

public record RoleUsuarioMergeCommand(
    string RoleId,
    IReadOnlyCollection<string> UsersId
) : IRequest, ICommandBase;
