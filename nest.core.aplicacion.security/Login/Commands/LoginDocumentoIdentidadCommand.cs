using MediatR;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Auth;

namespace nest.core.aplicacion.security.Login.Commands;

public record LoginDocumentoIdentidadCommand(
    int tipoDocumentoId,
    string documentoIdentidad
) : IRequest<CustomAccessTokenResponse>;
