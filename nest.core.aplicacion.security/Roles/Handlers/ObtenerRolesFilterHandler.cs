using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Roles.Queries;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Roles.Handlers;

public class ObtenerRolesFilterHandler : IRequestHandler<ObtenerRolesFilterQuery, LoadResult>
{
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly ILogger<ObtenerRolesFilterHandler> logger;

    public ObtenerRolesFilterHandler(RoleManager<ApplicationRole> roleManager, ILogger<ObtenerRolesFilterHandler> logger)
    {
        this.roleManager = roleManager;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerRolesFilterQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await DataSourceLoader.LoadAsync(roleManager.Roles, request.LoadOptions, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los roles con filtro");
            throw;
        }
    }
}
