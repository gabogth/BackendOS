using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Roles.Commands;
using nest.core.dominio.Excepciones;
using nest.core.dominio.Security;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.aplicacion.security.Roles.Handlers;

public class RoleModificarHandler : IRequestHandler<RoleModificarCommand, ApplicationRole>
{
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly NestDbContext context;
    private readonly ILogger<RoleModificarHandler> logger;

    public RoleModificarHandler(RoleManager<ApplicationRole> roleManager, NestDbContext context, ILogger<RoleModificarHandler> logger)
    {
        this.roleManager = roleManager;
        this.context = context;
        this.logger = logger;
    }

    public async Task<ApplicationRole> Handle(RoleModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            string roleId = request.Id.ToString();
            ApplicationRole currentRole = await context.Roles.FirstAsync(x => x.Id == roleId, cancellationToken);
            currentRole.Name = request.Name;
            currentRole.NormalizedName = request.Name.ToUpperInvariant();

            IdentityResult result = await roleManager.UpdateAsync(currentRole);
            if (!result.Succeeded)
                throw new IdentityException(result.Errors.Select(x => new nest.core.dominio.Excepciones.IdentityError { Code = x.Code, Description = x.Description }).ToList());

            return await roleManager.FindByNameAsync(request.Name);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar el rol {RoleId}", request.Id);
            throw;
        }
    }
}
