using MediatR;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;

namespace nest.core.aplicacion.security.Login.Commands;

public record LoginCommand(
    string Email,
    string Password,
    string? TwoFactorCode,
    string? TwoFactorRecoveryCode
) : IRequest<CustomAccessTokenResponse>, ILoginEmailCommand;
