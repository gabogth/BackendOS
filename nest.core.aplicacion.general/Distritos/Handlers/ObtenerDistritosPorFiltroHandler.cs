using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Distritos.Queries;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Distritos.Handlers;

public class ObtenerDistritosPorFiltroHandler : IRequestHandler<ObtenerDistritosPorFiltroQuery, LoadResult>
{
    private readonly IDistritoRepository repository;
    private readonly ILogger<ObtenerDistritosPorFiltroHandler> logger;

    public ObtenerDistritosPorFiltroHandler(IDistritoRepository repository, ILogger<ObtenerDistritosPorFiltroHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerDistritosPorFiltroQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los distritos por filtro");
            throw;
        }
    }
}
