using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Formularios.Queries;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Handlers;

public class ObtenerFormulariosPorModuloIdHandler : IRequestHandler<ObtenerFormulariosPorModuloIdQuery, List<Formulario>>
{
    private readonly IFormularioRepository repository;
    private readonly ILogger<ObtenerFormulariosPorModuloIdHandler> logger;

    public ObtenerFormulariosPorModuloIdHandler(IFormularioRepository repository, ILogger<ObtenerFormulariosPorModuloIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<Formulario>> Handle(ObtenerFormulariosPorModuloIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorModuloId(request.ModuloId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los formularios del módulo {ModuloId}", request.ModuloId);
            throw;
        }
    }
}
