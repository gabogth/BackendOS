using MediatR;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Roles.Queries;

public record ObtenerRolesQuery : IRequest<List<ApplicationRole>>;
