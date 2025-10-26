using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Handlers;

public class HorarioDetalleEventoModificarHandler : IRequestHandler<HorarioDetalleEventoModificarCommand, HorarioDetalleEvento>
{
    private readonly IHorarioDetalleEventoRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<HorarioDetalleEventoModificarHandler> logger;

    public HorarioDetalleEventoModificarHandler(IHorarioDetalleEventoRepository repository, IMapper mapper, ILogger<HorarioDetalleEventoModificarHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<HorarioDetalleEvento> Handle(HorarioDetalleEventoModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<HorarioDetalleEvento>(request);
            return await repository.Modificar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar el evento {Id}", request.Id);
            throw;
        }
    }
}
