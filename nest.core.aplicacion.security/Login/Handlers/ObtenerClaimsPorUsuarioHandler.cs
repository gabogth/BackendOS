using MediatR;
using System.Security.Claims;
using nest.core.aplicacion.security.Login.Queries;
using nest.core.dominio.Security.Repositorios;

namespace nest.core.aplicacion.security.Login.Handlers;

public class ObtenerClaimsPorUsuarioHandler : IRequestHandler<ObtenerClaimsPorUsuarioQuery, List<Claim>>
{
    private readonly IIdentityUserRepository repository;

    public ObtenerClaimsPorUsuarioHandler(IIdentityUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<List<Claim>> Handle(ObtenerClaimsPorUsuarioQuery request, CancellationToken cancellationToken)
    {
        return await this.repository.ObtenerClaims(request.Usuario.Id, cancellationToken);
    }
}
