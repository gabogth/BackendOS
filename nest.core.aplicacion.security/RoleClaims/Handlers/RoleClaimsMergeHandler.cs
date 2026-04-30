using System.Linq;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.RoleClaims.Commands;
using nest.core.dominio.Security;
using nest.core.dominio.Security.Repositorios;

namespace nest.core.aplicacion.security.RoleClaims.Handlers;

public class RoleClaimsMergeHandler : IRequestHandler<RoleClaimsMergeCommand>
{
    private readonly IIdentityRoleClaimRepository repository;
    private readonly ILogger<RoleClaimsMergeHandler> logger;

    public RoleClaimsMergeHandler(IIdentityRoleClaimRepository repository, ILogger<RoleClaimsMergeHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task Handle(RoleClaimsMergeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await this.repository.MergeRange(request.RoleId, request.Claims);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al actualizar los claims del rol {RoleId}", request.RoleId);
            throw;
        }
    }
}
