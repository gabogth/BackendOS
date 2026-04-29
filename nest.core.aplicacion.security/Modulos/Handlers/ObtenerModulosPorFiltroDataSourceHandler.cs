using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Modulos.Queries;
using nest.core.dominio.Aplicacion.Modulo.Repository;

namespace nest.core.aplicacion.security.Modulos.Handlers;

public class ObtenerModulosPorFiltroDataSourceHandler : IRequestHandler<ObtenerModulosPorFiltroDataSourceQuery, LoadResult>
{
    private readonly IModuloRepository repository;
    private readonly ILogger<ObtenerModulosPorFiltroDataSourceHandler> logger;

    public ObtenerModulosPorFiltroDataSourceHandler(IModuloRepository repository, ILogger<ObtenerModulosPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerModulosPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los módulos por filtro datasource");
            throw;
        }
    }
}
