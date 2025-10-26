using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Roles.Commands;

public record RoleCrearCommand(
    int EmpresaId,
    string Name
) : IRequest<ApplicationRole>, ICommandBase;
