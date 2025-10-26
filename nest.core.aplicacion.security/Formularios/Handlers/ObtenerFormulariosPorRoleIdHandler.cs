using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Formularios.Queries;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Handlers;

public class ObtenerFormulariosPorRoleIdHandler : IRequestHandler<ObtenerFormulariosPorRoleIdQuery, List<Formulario>>
{
    private readonly IFormularioRepository repository;
    private readonly ILogger<ObtenerFormulariosPorRoleIdHandler> logger;

    public ObtenerFormulariosPorRoleIdHandler(IFormularioRepository repository, ILogger<ObtenerFormulariosPorRoleIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<Formulario>> Handle(ObtenerFormulariosPorRoleIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorRolId(request.RoleId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los formularios del rol {RoleId}", request.RoleId);
            throw;
        }
    }
}
