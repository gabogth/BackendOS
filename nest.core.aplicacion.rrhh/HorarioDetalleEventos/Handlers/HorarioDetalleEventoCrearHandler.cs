using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Handlers;

public class HorarioDetalleEventoCrearHandler : IRequestHandler<HorarioDetalleEventoCrearCommand, HorarioDetalleEvento>
{
    private readonly IHorarioDetalleEventoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<HorarioDetalleEventoCrearHandler> logger;

    public HorarioDetalleEventoCrearHandler(IHorarioDetalleEventoRepository repository, IMapper mapper, ILogger<HorarioDetalleEventoCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<HorarioDetalleEvento> Handle(HorarioDetalleEventoCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<HorarioDetalleEvento>(request);
            return await repository.Agregar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al registrar el evento del horario {HorarioDetalleId}", request.HorarioDetalleId);
            throw;
        }
    }
}
