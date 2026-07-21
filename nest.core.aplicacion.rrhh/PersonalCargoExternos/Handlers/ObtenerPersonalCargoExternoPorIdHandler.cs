using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Queries;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Handlers;

public class ObtenerPersonalCargoExternoPorIdHandler : IRequestHandler<ObtenerPersonalCargoExternoPorIdQuery, PersonalCargoExterno>
{
    private readonly IPersonalCargoExternoRepository repository;
    private readonly ILogger<ObtenerPersonalCargoExternoPorIdHandler> logger;

    public ObtenerPersonalCargoExternoPorIdHandler(IPersonalCargoExternoRepository repository, ILogger<ObtenerPersonalCargoExternoPorIdHandler> logger)
    { this.repository = repository; this.logger = logger; }

    public async Task<PersonalCargoExterno> Handle(ObtenerPersonalCargoExternoPorIdQuery request, CancellationToken cancellationToken)
    {
        try { return await repository.ObtenerPorId(request.Id); }
        catch (Exception ex) { logger.LogError(ex, "Error al obtener el cargo externo del personal {Id}", request.Id); throw; }
    }
}
