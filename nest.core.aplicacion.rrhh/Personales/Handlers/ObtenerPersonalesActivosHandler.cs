using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Personales.Queries;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Handlers;

public class ObtenerPersonalesActivosHandler : IRequestHandler<ObtenerPersonalesActivosQuery, List<Personal>>
{
    private readonly IPersonalRepository repository;
    private readonly ILogger<ObtenerPersonalesActivosHandler> logger;

    public ObtenerPersonalesActivosHandler(IPersonalRepository repository, ILogger<ObtenerPersonalesActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<Personal>> Handle(ObtenerPersonalesActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerActivos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el personal activo");
            throw;
        }
    }
}
