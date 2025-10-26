using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Queries;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Handlers;

public class ObtenerGrupoTrabajoPersonasPorGrupoHandler : IRequestHandler<ObtenerGrupoTrabajoPersonasPorGrupoQuery, List<GrupoTrabajoPersona>>
{
    private readonly IGrupoTrabajoPersonaRepository repository;
    private readonly ILogger<ObtenerGrupoTrabajoPersonasPorGrupoHandler> logger;

    public ObtenerGrupoTrabajoPersonasPorGrupoHandler(IGrupoTrabajoPersonaRepository repository, ILogger<ObtenerGrupoTrabajoPersonasPorGrupoHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<GrupoTrabajoPersona>> Handle(ObtenerGrupoTrabajoPersonasPorGrupoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorGrupoTrabajo(request.GrupoTrabajoId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener las personas del grupo de trabajo {GrupoTrabajoId}", request.GrupoTrabajoId);
            throw;
        }
    }
}
