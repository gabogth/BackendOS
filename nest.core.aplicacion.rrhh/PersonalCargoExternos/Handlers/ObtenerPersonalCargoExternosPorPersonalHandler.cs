using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Queries;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Handlers;

public class ObtenerPersonalCargoExternosPorPersonalHandler : IRequestHandler<ObtenerPersonalCargoExternosPorPersonalQuery, List<PersonalCargoExterno>>
{
    private readonly IPersonalCargoExternoRepository repository;
    private readonly ILogger<ObtenerPersonalCargoExternosPorPersonalHandler> logger;

    public ObtenerPersonalCargoExternosPorPersonalHandler(IPersonalCargoExternoRepository repository, ILogger<ObtenerPersonalCargoExternosPorPersonalHandler> logger)
    { this.repository = repository; this.logger = logger; }

    public async Task<List<PersonalCargoExterno>> Handle(ObtenerPersonalCargoExternosPorPersonalQuery request, CancellationToken cancellationToken)
    {
        try { return await repository.ObtenerPorPersonal(request.PersonalId); }
        catch (Exception ex) { logger.LogError(ex, "Error al obtener los cargos externos del personal {PersonalId}", request.PersonalId); throw; }
    }
}
