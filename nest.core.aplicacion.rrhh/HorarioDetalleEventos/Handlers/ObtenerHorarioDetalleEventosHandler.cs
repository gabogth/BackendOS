using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Queries;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Handlers;

public class ObtenerHorarioDetalleEventosHandler : IRequestHandler<ObtenerHorarioDetalleEventosQuery, List<HorarioDetalleEvento>>
{
    private readonly IHorarioDetalleEventoRepository repository;
    private readonly ILogger<ObtenerHorarioDetalleEventosHandler> logger;

    public ObtenerHorarioDetalleEventosHandler(IHorarioDetalleEventoRepository repository, ILogger<ObtenerHorarioDetalleEventosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<HorarioDetalleEvento>> Handle(ObtenerHorarioDetalleEventosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerTodos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los eventos de horarios");
            throw;
        }
    }
}
