using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;

namespace nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Handlers;

public class GrupoTrabajoPersonaEliminarHandler : IRequestHandler<GrupoTrabajoPersonaEliminarCommand, Unit>
{
    private readonly IGrupoTrabajoPersonaRepository repository;
    private readonly ILogger<GrupoTrabajoPersonaEliminarHandler> logger;

    public GrupoTrabajoPersonaEliminarHandler(IGrupoTrabajoPersonaRepository repository, ILogger<GrupoTrabajoPersonaEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Unit> Handle(GrupoTrabajoPersonaEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.Eliminar(request.Id);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar la persona {Id} del grupo de trabajo", request.Id);
            throw;
        }
    }
}
