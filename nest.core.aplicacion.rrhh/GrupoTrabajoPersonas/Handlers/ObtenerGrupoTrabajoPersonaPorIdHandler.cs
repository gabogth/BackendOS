using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Queries;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Handlers;

public class ObtenerGrupoTrabajoPersonaPorIdHandler : IRequestHandler<ObtenerGrupoTrabajoPersonaPorIdQuery, GrupoTrabajoPersona>
{
    private readonly IGrupoTrabajoPersonaRepository repository;
    private readonly ILogger<ObtenerGrupoTrabajoPersonaPorIdHandler> logger;

    public ObtenerGrupoTrabajoPersonaPorIdHandler(IGrupoTrabajoPersonaRepository repository, ILogger<ObtenerGrupoTrabajoPersonaPorIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<GrupoTrabajoPersona> Handle(ObtenerGrupoTrabajoPersonaPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorId(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener la persona del grupo de trabajo {Id}", request.Id);
            throw;
        }
    }
}
