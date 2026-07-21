using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Queries;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Handlers;

public class ObtenerPersonalCargoExternosPorCargoHandler : IRequestHandler<ObtenerPersonalCargoExternosPorCargoQuery, List<PersonalCargoExterno>>
{
    private readonly IPersonalCargoExternoRepository repository;
    private readonly ILogger<ObtenerPersonalCargoExternosPorCargoHandler> logger;

    public ObtenerPersonalCargoExternosPorCargoHandler(IPersonalCargoExternoRepository repository, ILogger<ObtenerPersonalCargoExternosPorCargoHandler> logger)
    { this.repository = repository; this.logger = logger; }

    public async Task<List<PersonalCargoExterno>> Handle(ObtenerPersonalCargoExternosPorCargoQuery request, CancellationToken cancellationToken)
    {
        try { return await repository.ObtenerPorCargo(request.CargoId); }
        catch (Exception ex) { logger.LogError(ex, "Error al obtener los cargos externos por cargo {CargoId}", request.CargoId); throw; }
    }
}
