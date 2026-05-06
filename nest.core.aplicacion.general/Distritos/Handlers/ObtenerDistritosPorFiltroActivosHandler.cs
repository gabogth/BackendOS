using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Distritos.Queries;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Distritos.Handlers;

public class ObtenerDistritosPorFiltroActivosHandler : IRequestHandler<ObtenerDistritosPorFiltroActivosQuery, LoadResult>
{
    private readonly IDistritoRepository repository;
    private readonly ILogger<ObtenerDistritosPorFiltroActivosHandler> logger;

    public ObtenerDistritosPorFiltroActivosHandler(IDistritoRepository repository, ILogger<ObtenerDistritosPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerDistritosPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los distritos activos por filtro");
            throw;
        }
    }
}
