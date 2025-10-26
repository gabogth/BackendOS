using System.Linq;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Formularios.Queries;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Handlers;

public class ObtenerFormulariosPorFiltroHandler : IRequestHandler<ObtenerFormulariosPorFiltroQuery, List<Formulario>>
{
    private readonly IFormularioRepository repository;
    private readonly ILogger<ObtenerFormulariosPorFiltroHandler> logger;

    public ObtenerFormulariosPorFiltroHandler(IFormularioRepository repository, ILogger<ObtenerFormulariosPorFiltroHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<Formulario>> Handle(ObtenerFormulariosPorFiltroQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorUnaPropiedad(request.Filtros.ToDictionary(k => k.Key, v => v.Value));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los formularios por filtro");
            throw;
        }
    }
}
