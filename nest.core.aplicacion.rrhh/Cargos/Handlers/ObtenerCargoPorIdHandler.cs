using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Cargos.Queries;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Handlers;

public class ObtenerCargoPorIdHandler : IRequestHandler<ObtenerCargoPorIdQuery, Cargo>
{
    private readonly ICargoRepository repository;
    private readonly ILogger<ObtenerCargoPorIdHandler> logger;

    public ObtenerCargoPorIdHandler(ICargoRepository repository, ILogger<ObtenerCargoPorIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Cargo> Handle(ObtenerCargoPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorId(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el cargo {Id}", request.Id);
            throw;
        }
    }
}
