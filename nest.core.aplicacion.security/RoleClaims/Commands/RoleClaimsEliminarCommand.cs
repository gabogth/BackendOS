using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.security.RoleClaims.Commands;

public record RoleClaimsEliminarCommand(string RoleId) : IRequest<Unit>, ICommandBase;
