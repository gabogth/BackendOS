using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Formularios.Queries;
using nest.core.dominio.Aplicacion.Formulario;
using nest.core.dominio.Security.Tenant;

namespace nest.core.aplicacion.security.Formularios.Handlers;

public class ObtenerFormularioPorUserIdHandler : IRequestHandler<ObtenerFormularioPorUserIdQuery, List<Formulario>>
{
    private readonly IFormularioRepository repository;
    private readonly IConnectionStringService connection;
    private readonly ILogger<ObtenerFormularioPorUserIdHandler> logger;

    public ObtenerFormularioPorUserIdHandler(IFormularioRepository repository, IConnectionStringService connection, ILogger<ObtenerFormularioPorUserIdHandler> logger)
    {
        this.repository = repository;
        this.connection = connection;
        this.logger = logger;
    }

    public async Task<List<Formulario>> Handle(ObtenerFormularioPorUserIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorUserId(connection.UserId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el formulario del usuario {Id}", connection.UserId);
            throw;
        }
    }
}
