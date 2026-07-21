using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Commands;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Handlers;

public class PersonalCargoExternoEliminarHandler : IRequestHandler<PersonalCargoExternoEliminarCommand, Unit>
{
    private readonly IPersonalCargoExternoRepository repository;
    private readonly ILogger<PersonalCargoExternoEliminarHandler> logger;

    public PersonalCargoExternoEliminarHandler(IPersonalCargoExternoRepository repository, ILogger<PersonalCargoExternoEliminarHandler> logger)
    { this.repository = repository; this.logger = logger; }

    public async Task<Unit> Handle(PersonalCargoExternoEliminarCommand request, CancellationToken cancellationToken)
    {
        try { await repository.Eliminar(request.Id); return Unit.Value; }
        catch (Exception ex) { logger.LogError(ex, "Error al eliminar el cargo externo del personal {Id}", request.Id); throw; }
    }
}
