using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Queries;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Handlers;

public class ObtenerPersonalCargoExternosHandler : IRequestHandler<ObtenerPersonalCargoExternosQuery, List<PersonalCargoExterno>>
{
    private readonly IPersonalCargoExternoRepository repository;
    private readonly ILogger<ObtenerPersonalCargoExternosHandler> logger;

    public ObtenerPersonalCargoExternosHandler(IPersonalCargoExternoRepository repository, ILogger<ObtenerPersonalCargoExternosHandler> logger)
    { this.repository = repository; this.logger = logger; }

    public async Task<List<PersonalCargoExterno>> Handle(ObtenerPersonalCargoExternosQuery request, CancellationToken cancellationToken)
    {
        try { return await repository.ObtenerTodos(); }
        catch (Exception ex) { logger.LogError(ex, "Error al obtener los cargos externos del personal"); throw; }
    }
}
