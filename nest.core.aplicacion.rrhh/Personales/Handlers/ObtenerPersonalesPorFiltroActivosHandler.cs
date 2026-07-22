using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Personales.Queries;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Handlers;

public class ObtenerPersonalesPorFiltroActivosHandler : IRequestHandler<ObtenerPersonalesPorFiltroActivosQuery, LoadResult>
{
    private readonly IPersonalRepository repository;
    private readonly ILogger<ObtenerPersonalesPorFiltroActivosHandler> logger;

    public ObtenerPersonalesPorFiltroActivosHandler(IPersonalRepository repository, ILogger<ObtenerPersonalesPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerPersonalesPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el personal activo por filtro datasource");
            throw;
        }
    }
}
