using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Cargos.Commands;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Handlers;

public class CargoModificarHandler : IRequestHandler<CargoModificarCommand, Cargo>
{
    private readonly ICargoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CargoModificarHandler> logger;

    public CargoModificarHandler(ICargoRepository repository, IMapper mapper, ILogger<CargoModificarHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Cargo> Handle(CargoModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<Cargo>(request);
            return await repository.Modificar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar el cargo {Id}", request.Id);
            throw;
        }
    }
}
