using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.security.Roles.Commands;

public record RoleEliminarCommand(int Id) : IRequest<Unit>, ICommandBase;
