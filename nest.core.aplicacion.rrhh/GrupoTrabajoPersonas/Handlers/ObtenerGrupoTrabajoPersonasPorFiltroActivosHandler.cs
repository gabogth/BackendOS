using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Queries;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Handlers;

public class ObtenerGrupoTrabajoPersonasPorFiltroActivosHandler : IRequestHandler<ObtenerGrupoTrabajoPersonasPorFiltroActivosQuery, LoadResult>
{
    private readonly IGrupoTrabajoPersonaRepository repository;
    private readonly ILogger<ObtenerGrupoTrabajoPersonasPorFiltroActivosHandler> logger;

    public ObtenerGrupoTrabajoPersonasPorFiltroActivosHandler(IGrupoTrabajoPersonaRepository repository, ILogger<ObtenerGrupoTrabajoPersonasPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerGrupoTrabajoPersonasPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener las personas de grupo de trabajo activas por filtro datasource");
            throw;
        }
    }
}
