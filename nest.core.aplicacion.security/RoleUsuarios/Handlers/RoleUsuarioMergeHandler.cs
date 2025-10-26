using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.RoleUsuarios.Commands;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.RoleUsuarios.Handlers;

public class RoleUsuarioMergeHandler : IRequestHandler<RoleUsuarioMergeCommand, Unit>
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly ILogger<RoleUsuarioMergeHandler> logger;

    public RoleUsuarioMergeHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ILogger<RoleUsuarioMergeHandler> logger)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.logger = logger;
    }

    public async Task<Unit> Handle(RoleUsuarioMergeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ApplicationRole? role = await roleManager.FindByNameAsync(request.RoleName);
            if (role is null)
                throw new InvalidOperationException($"Rol {request.RoleName} no encontrado");

            IList<ApplicationUser> currentUsers = await userManager.GetUsersInRoleAsync(request.RoleName);
            foreach (var user in currentUsers)
            {
                IdentityResult removeResult = await userManager.RemoveFromRoleAsync(user, request.RoleName);
                if (!removeResult.Succeeded)
                    throw new Exception(string.Join(", ", removeResult.Errors.Select(p => p.Description)));
            }

            List<ApplicationUser> usuarios = await userManager.Users.Where(x => request.UsersId.Contains(x.Id)).ToListAsync(cancellationToken);
            foreach (ApplicationUser user in usuarios)
            {
                IdentityResult result = await userManager.AddToRoleAsync(user, request.RoleName);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(p => p.Description)));
            }

            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al actualizar los usuarios del rol {Role}", request.RoleName);
            throw;
        }
    }
}
