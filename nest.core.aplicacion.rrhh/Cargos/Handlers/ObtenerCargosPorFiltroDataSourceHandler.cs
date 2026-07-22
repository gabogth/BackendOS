using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Cargos.Queries;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Handlers;

public class ObtenerCargosPorFiltroDataSourceHandler : IRequestHandler<ObtenerCargosPorFiltroDataSourceQuery, LoadResult>
{
    private readonly ICargoRepository repository;
    private readonly ILogger<ObtenerCargosPorFiltroDataSourceHandler> logger;

    public ObtenerCargosPorFiltroDataSourceHandler(ICargoRepository repository, ILogger<ObtenerCargosPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerCargosPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los cargos por filtro datasource");
            throw;
        }
    }
}
