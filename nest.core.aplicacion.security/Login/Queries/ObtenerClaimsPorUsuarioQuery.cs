using System.Security.Claims;
using MediatR;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Login.Queries;

public record ObtenerClaimsPorUsuarioQuery(ApplicationUser Usuario) : IRequest<List<Claim>>;
