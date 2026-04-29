using System.Linq;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Formularios.Queries;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Handlers;

public class ObtenerFormulariosPorFiltroActivosHandler : IRequestHandler<ObtenerFormulariosPorFiltroQuery, LoadResult>
{
    private readonly IFormularioRepository repository;
    private readonly ILogger<ObtenerFormulariosPorFiltroActivosHandler> logger;

    public ObtenerFormulariosPorFiltroActivosHandler(IFormularioRepository repository, ILogger<ObtenerFormulariosPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerFormulariosPorFiltroQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los formularios por filtro");
            throw;
        }
    }
}
