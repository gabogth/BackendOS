using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Queries;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Handlers;

public class ObtenerGrupoTrabajoPersonasPorFiltroDataSourceHandler : IRequestHandler<ObtenerGrupoTrabajoPersonasPorFiltroDataSourceQuery, LoadResult>
{
    private readonly IGrupoTrabajoPersonaRepository repository;
    private readonly ILogger<ObtenerGrupoTrabajoPersonasPorFiltroDataSourceHandler> logger;

    public ObtenerGrupoTrabajoPersonasPorFiltroDataSourceHandler(IGrupoTrabajoPersonaRepository repository, ILogger<ObtenerGrupoTrabajoPersonasPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerGrupoTrabajoPersonasPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener las personas de grupo de trabajo por filtro datasource");
            throw;
        }
    }
}
