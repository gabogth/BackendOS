using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.logistica.Almacenes.Queries;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Handlers;

public class ObtenerAlmacenesPorFiltroActivoHandler : IRequestHandler<ObtenerAlmacenesPorFiltroActivoQuery, LoadResult>
{
    private readonly IAlmacenRepository repository;
    private readonly ILogger<ObtenerAlmacenesPorFiltroActivoHandler> logger;

    public ObtenerAlmacenesPorFiltroActivoHandler(IAlmacenRepository repository, ILogger<ObtenerAlmacenesPorFiltroActivoHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerAlmacenesPorFiltroActivoQuery request, CancellationToken cancellationToken)
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
