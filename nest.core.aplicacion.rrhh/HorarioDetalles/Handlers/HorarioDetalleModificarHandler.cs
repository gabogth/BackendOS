using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.HorarioDetalles.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Handlers;

public class HorarioDetalleModificarHandler : IRequestHandler<HorarioDetalleModificarCommand, HorarioDetalle>
{
    private readonly IHorarioDetalleRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<HorarioDetalleModificarHandler> logger;

    public HorarioDetalleModificarHandler(IHorarioDetalleRepository repository, IMapper mapper, ILogger<HorarioDetalleModificarHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<HorarioDetalle> Handle(HorarioDetalleModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<HorarioDetalle>(request);
            return await repository.Modificar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar el detalle {Id}", request.Id);
            throw;
        }
    }
}
