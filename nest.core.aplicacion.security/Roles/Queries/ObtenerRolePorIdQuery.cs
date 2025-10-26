using MediatR;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Roles.Queries;

public record ObtenerRolePorIdQuery(string Id) : IRequest<ApplicationRole>;
