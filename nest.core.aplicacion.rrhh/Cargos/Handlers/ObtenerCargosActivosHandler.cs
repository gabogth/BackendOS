using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Cargos.Queries;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Handlers;

public class ObtenerCargosActivosHandler : IRequestHandler<ObtenerCargosActivosQuery, List<Cargo>>
{
    private readonly ICargoRepository repository;
    private readonly ILogger<ObtenerCargosActivosHandler> logger;

    public ObtenerCargosActivosHandler(ICargoRepository repository, ILogger<ObtenerCargosActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<Cargo>> Handle(ObtenerCargosActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerActivos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los cargos activos");
            throw;
        }
    }
}
