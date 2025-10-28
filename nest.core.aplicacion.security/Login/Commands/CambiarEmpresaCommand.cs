using MediatR;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;

namespace nest.core.aplicacion.security.Login.Commands;

public record CambiarEmpresaCommand(
    string Email,
    int EmpresaId
) : IRequest<CustomAccessTokenResponse>, ILoginEmailCommand;
