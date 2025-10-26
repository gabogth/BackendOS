using MediatR;
using System.Security.Claims;

namespace nest.core.aplicacion.security.RoleClaims.Queries;

public record ObtenerRoleClaimsQuery(string RoleId) : IRequest<List<Claim>>;
