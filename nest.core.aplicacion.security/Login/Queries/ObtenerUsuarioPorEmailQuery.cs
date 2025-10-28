using MediatR;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Login.Queries;

public record ObtenerUsuarioPorEmailQuery(string Email) : IRequest<ApplicationUser?>;
