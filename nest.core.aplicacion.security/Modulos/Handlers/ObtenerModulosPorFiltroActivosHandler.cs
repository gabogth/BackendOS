using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Modulos.Queries;
using nest.core.dominio.Aplicacion.Modulo.Repository;

namespace nest.core.aplicacion.security.Modulos.Handlers;

public class ObtenerModulosPorFiltroActivosHandler : IRequestHandler<ObtenerModulosPorFiltroActivosQuery, LoadResult>
{
    private readonly IModuloRepository repository;
    private readonly ILogger<ObtenerModulosPorFiltroActivosHandler> logger;

    public ObtenerModulosPorFiltroActivosHandler(IModuloRepository repository, ILogger<ObtenerModulosPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerModulosPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los módulos activos por filtro datasource");
            throw;
        }
    }
}
