using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.RoleUsuarios.Commands;
using nest.core.dominio.Security.Repositorios;

namespace nest.core.aplicacion.security.RoleUsuarios.Handlers;

public class RoleUsuarioMergeHandler : IRequestHandler<RoleUsuarioMergeCommand>
{
    private readonly IIdentityRoleUserRepository repository;
    private readonly ILogger<RoleUsuarioMergeHandler> logger;

    public RoleUsuarioMergeHandler(IIdentityRoleUserRepository repository, ILogger<RoleUsuarioMergeHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task Handle(RoleUsuarioMergeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.MergeRange(request.RoleId, request.UsersId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al actualizar los usuarios del rol {Role}", request.RoleId);
            throw;
        }
    }
}
