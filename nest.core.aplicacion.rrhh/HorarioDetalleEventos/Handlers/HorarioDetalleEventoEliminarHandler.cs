using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Handlers;

public class HorarioDetalleEventoEliminarHandler : IRequestHandler<HorarioDetalleEventoEliminarCommand, Unit>
{
    private readonly IHorarioDetalleEventoRepository repository;
    private readonly ILogger<HorarioDetalleEventoEliminarHandler> logger;

    public HorarioDetalleEventoEliminarHandler(IHorarioDetalleEventoRepository repository, ILogger<HorarioDetalleEventoEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Unit> Handle(HorarioDetalleEventoEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.Eliminar(request.Id);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar el evento {Id}", request.Id);
            throw;
        }
    }
}
