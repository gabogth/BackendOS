using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Formularios.Queries;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Handlers;

public class ObtenerFormulariosHandler : IRequestHandler<ObtenerFormulariosQuery, List<Formulario>>
{
    private readonly IFormularioRepository repository;
    private readonly ILogger<ObtenerFormulariosHandler> logger;

    public ObtenerFormulariosHandler(IFormularioRepository repository, ILogger<ObtenerFormulariosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<Formulario>> Handle(ObtenerFormulariosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerTodos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los formularios");
            throw;
        }
    }
}
