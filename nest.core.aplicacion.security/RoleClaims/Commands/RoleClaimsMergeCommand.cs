using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Security.Dto;

namespace nest.core.aplicacion.security.RoleClaims.Commands;

public record RoleClaimsMergeCommand(
    string RoleId,
    IReadOnlyCollection<ClaimDto> Claims
) : IRequest<Unit>, ICommandBase;
