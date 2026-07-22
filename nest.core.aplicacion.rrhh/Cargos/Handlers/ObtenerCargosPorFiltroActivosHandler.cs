using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Cargos.Queries;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Handlers;

public class ObtenerCargosPorFiltroActivosHandler : IRequestHandler<ObtenerCargosPorFiltroActivosQuery, LoadResult>
{
    private readonly ICargoRepository repository;
    private readonly ILogger<ObtenerCargosPorFiltroActivosHandler> logger;

    public ObtenerCargosPorFiltroActivosHandler(ICargoRepository repository, ILogger<ObtenerCargosPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerCargosPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los cargos activos por filtro datasource");
            throw;
        }
    }
}
