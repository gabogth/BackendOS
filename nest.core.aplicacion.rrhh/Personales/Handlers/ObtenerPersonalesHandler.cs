using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Personales.Queries;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Handlers;

public class ObtenerPersonalesHandler : IRequestHandler<ObtenerPersonalesQuery, List<Personal>>
{
    private readonly IPersonalRepository repository;
    private readonly ILogger<ObtenerPersonalesHandler> logger;

    public ObtenerPersonalesHandler(IPersonalRepository repository, ILogger<ObtenerPersonalesHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<Personal>> Handle(ObtenerPersonalesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerTodos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el personal");
            throw;
        }
    }
}
