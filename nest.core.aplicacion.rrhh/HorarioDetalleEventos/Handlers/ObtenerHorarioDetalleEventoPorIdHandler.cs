using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Queries;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Handlers;

public class ObtenerHorarioDetalleEventoPorIdHandler : IRequestHandler<ObtenerHorarioDetalleEventoPorIdQuery, HorarioDetalleEvento>
{
    private readonly IHorarioDetalleEventoRepository repository;
    private readonly ILogger<ObtenerHorarioDetalleEventoPorIdHandler> logger;

    public ObtenerHorarioDetalleEventoPorIdHandler(IHorarioDetalleEventoRepository repository, ILogger<ObtenerHorarioDetalleEventoPorIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<HorarioDetalleEvento> Handle(ObtenerHorarioDetalleEventoPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorId(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el evento {Id}", request.Id);
            throw;
        }
    }
}
