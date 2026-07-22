using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Queries;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajos.Handlers;

public class ObtenerGrupoTrabajosPorFiltroDataSourceHandler : IRequestHandler<ObtenerGrupoTrabajosPorFiltroDataSourceQuery, LoadResult>
{
    private readonly IGrupoTrabajoRepository repository;
    private readonly ILogger<ObtenerGrupoTrabajosPorFiltroDataSourceHandler> logger;

    public ObtenerGrupoTrabajosPorFiltroDataSourceHandler(IGrupoTrabajoRepository repository, ILogger<ObtenerGrupoTrabajosPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerGrupoTrabajosPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los grupos de trabajo por filtro datasource");
            throw;
        }
    }
}
