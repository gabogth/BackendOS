using MediatR;
using Microsoft.AspNetCore.Identity;
using nest.core.aplicacion.security.Login.Queries;
using nest.core.dominio.Security;

namespace nest.core.aplicacion.security.Login.Handlers;

public class ObtenerUsuarioPorEmailHandler : IRequestHandler<ObtenerUsuarioPorEmailQuery, ApplicationUser?>
{
    private readonly UserManager<ApplicationUser> userManager;

    public ObtenerUsuarioPorEmailHandler(UserManager<ApplicationUser> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<ApplicationUser?> Handle(ObtenerUsuarioPorEmailQuery request, CancellationToken cancellationToken)
    {
        return await userManager.FindByEmailAsync(request.Email);
    }
}
