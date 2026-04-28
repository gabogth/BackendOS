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

public class RoleCrearHandler : IRequestHandler<RoleCrearCommand, ApplicationRole>
{
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly NestDbContext context;
    private readonly ILogger<RoleCrearHandler> logger;

    public RoleCrearHandler(RoleManager<ApplicationRole> roleManager, NestDbContext context, ILogger<RoleCrearHandler> logger)
    {
        this.roleManager = roleManager;
        this.context = context;
        this.logger = logger;
    }

    public async Task<ApplicationRole> Handle(RoleCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            string lastValue = await context.Roles
                .IgnoreQueryFilters()
                .OrderByDescending(r => Convert.ToInt64(r.Id))
                .Select(r => r.Id)
                .FirstOrDefaultAsync(cancellationToken) ?? "0";

            var newRole = new ApplicationRole
            {
                Id = (long.Parse(lastValue) + 1).ToString(),
                Name = request.Name,
                NormalizedName = request.Name.ToUpperInvariant(),
                EmpresaId = request.EmpresaId,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = await roleManager.CreateAsync(newRole);
            if (!result.Succeeded)
                throw new IdentityException(result.Errors.Select(x => new nest.core.dominio.Excepciones.IdentityError { Code = x.Code, Description = x.Description }).ToList());

            return await roleManager.FindByNameAsync(newRole.Name);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al crear el rol {Role}", request.Name);
            throw;
        }
    }
}
