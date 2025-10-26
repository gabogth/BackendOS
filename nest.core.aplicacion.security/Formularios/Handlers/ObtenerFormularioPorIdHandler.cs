using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Formularios.Queries;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Handlers;

public class ObtenerFormularioPorIdHandler : IRequestHandler<ObtenerFormularioPorIdQuery, Formulario>
{
    private readonly IFormularioRepository repository;
    private readonly ILogger<ObtenerFormularioPorIdHandler> logger;

    public ObtenerFormularioPorIdHandler(IFormularioRepository repository, ILogger<ObtenerFormularioPorIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Formulario> Handle(ObtenerFormularioPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorId(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el formulario {Id}", request.Id);
            throw;
        }
    }
}
