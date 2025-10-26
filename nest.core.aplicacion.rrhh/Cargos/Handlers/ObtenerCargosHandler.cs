using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Cargos.Queries;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Handlers;

public class ObtenerCargosHandler : IRequestHandler<ObtenerCargosQuery, List<Cargo>>
{
    private readonly ICargoRepository repository;
    private readonly ILogger<ObtenerCargosHandler> logger;

    public ObtenerCargosHandler(ICargoRepository repository, ILogger<ObtenerCargosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<Cargo>> Handle(ObtenerCargosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerTodos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los cargos");
            throw;
        }
    }
}
