using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Cargos.Commands;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Handlers;

public class CargoEliminarHandler : IRequestHandler<CargoEliminarCommand, Unit>
{
    private readonly ICargoRepository repository;
    private readonly ILogger<CargoEliminarHandler> logger;

    public CargoEliminarHandler(ICargoRepository repository, ILogger<CargoEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Unit> Handle(CargoEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.Eliminar(request.Id);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar el cargo {Id}", request.Id);
            throw;
        }
    }
}
