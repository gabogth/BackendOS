using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.logistica.Almacenes.Queries;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Handlers;

public class ObtenerAlmacenesPorFiltroHandler : IRequestHandler<ObtenerAlmacenesPorFiltroQuery, LoadResult>
{
    private readonly IAlmacenRepository repository;
    private readonly ILogger<ObtenerAlmacenesPorFiltroHandler> logger;

    public ObtenerAlmacenesPorFiltroHandler(IAlmacenRepository repository, ILogger<ObtenerAlmacenesPorFiltroHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerAlmacenesPorFiltroQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los formularios por filtro");
            throw;
        }
    }
}
