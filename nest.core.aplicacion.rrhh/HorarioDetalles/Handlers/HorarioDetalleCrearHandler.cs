using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.HorarioDetalles.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Handlers;

public class HorarioDetalleCrearHandler : IRequestHandler<HorarioDetalleCrearCommand, HorarioDetalle>
{
    private readonly IHorarioDetalleRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<HorarioDetalleCrearHandler> logger;

    public HorarioDetalleCrearHandler(IHorarioDetalleRepository repository, IMapper mapper, ILogger<HorarioDetalleCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<HorarioDetalle> Handle(HorarioDetalleCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<HorarioDetalle>(request);
            return await repository.Agregar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al crear el detalle para la cabecera {HorarioCabeceraId}", request.HorarioCabeceraId);
            throw;
        }
    }
}
