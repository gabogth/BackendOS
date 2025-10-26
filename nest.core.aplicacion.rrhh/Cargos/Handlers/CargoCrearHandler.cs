using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Cargos.Commands;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Handlers;

public class CargoCrearHandler : IRequestHandler<CargoCrearCommand, Cargo>
{
    private readonly ICargoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<CargoCrearHandler> logger;

    public CargoCrearHandler(ICargoRepository repository, IMapper mapper, ILogger<CargoCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Cargo> Handle(CargoCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<Cargo>(request);
            return await repository.Agregar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al crear el cargo {Nombre}", request.Nombre);
            throw;
        }
    }
}
