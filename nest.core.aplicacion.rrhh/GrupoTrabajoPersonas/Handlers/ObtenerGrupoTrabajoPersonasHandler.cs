using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Queries;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Handlers;

public class ObtenerGrupoTrabajoPersonasHandler : IRequestHandler<ObtenerGrupoTrabajoPersonasQuery, List<GrupoTrabajoPersona>>
{
    private readonly IGrupoTrabajoPersonaRepository repository;
    private readonly ILogger<ObtenerGrupoTrabajoPersonasHandler> logger;

    public ObtenerGrupoTrabajoPersonasHandler(IGrupoTrabajoPersonaRepository repository, ILogger<ObtenerGrupoTrabajoPersonasHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<GrupoTrabajoPersona>> Handle(ObtenerGrupoTrabajoPersonasQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerTodos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener las personas de grupos de trabajo");
            throw;
        }
    }
}
