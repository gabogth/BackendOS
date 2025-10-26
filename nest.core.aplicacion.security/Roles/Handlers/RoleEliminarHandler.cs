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

public class RoleEliminarHandler : IRequestHandler<RoleEliminarCommand, Unit>
{
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly NestDbContext context;
    private readonly ILogger<RoleEliminarHandler> logger;

    public RoleEliminarHandler(RoleManager<ApplicationRole> roleManager, NestDbContext context, ILogger<RoleEliminarHandler> logger)
    {
        this.roleManager = roleManager;
        this.context = context;
        this.logger = logger;
    }

    public async Task<Unit> Handle(RoleEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            string roleId = request.Id.ToString();
            ApplicationRole currentRole = await context.Roles.FirstAsync(x => x.Id == roleId, cancellationToken);
            IdentityResult result = await roleManager.DeleteAsync(currentRole);
            if (!result.Succeeded)
                throw new IdentityException(result.Errors.Select(x => new nest.core.dominio.Excepciones.IdentityError { Code = x.Code, Description = x.Description }).ToList());

            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar el rol {RoleId}", request.Id);
            throw;
        }
    }
}
