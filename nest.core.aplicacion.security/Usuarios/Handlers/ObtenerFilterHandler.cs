using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Usuarios.Queries;
using nest.core.dominio.Security;
using nest.core.infrastructura.utils.DataLoader;

namespace nest.core.aplicacion.security.Usuarios.Handlers
{
    public sealed class ObtenerFilterHandler : IRequestHandler<ObtenerFilterQuery, LoadResult>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<ObtenerFilterHandler> logger;

        public ObtenerFilterHandler(UserManager<ApplicationUser> userManager, ILogger<ObtenerFilterHandler> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
        }

        public async Task<LoadResult> Handle(ObtenerFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await DataSourceLoaderLw.LoadAsync(userManager.Users, request.loadOptions);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los usuarios");
                throw;
            }
        }
    }
}
