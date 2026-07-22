using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Queries;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Handlers;

public class ObtenerGrupoTrabajosPorFiltroActivosHandler : IRequestHandler<ObtenerGrupoTrabajosPorFiltroActivosQuery, LoadResult>
{
    private readonly IGrupoTrabajoRepository repository;
    private readonly ILogger<ObtenerGrupoTrabajosPorFiltroActivosHandler> logger;

    public ObtenerGrupoTrabajosPorFiltroActivosHandler(IGrupoTrabajoRepository repository, ILogger<ObtenerGrupoTrabajosPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerGrupoTrabajosPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los grupos de trabajo activos por filtro datasource");
            throw;
        }
    }
}
