using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.HorarioDetalles.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Handlers;

public class HorarioDetalleEliminarHandler : IRequestHandler<HorarioDetalleEliminarCommand, Unit>
{
    private readonly IHorarioDetalleRepository repository;
    private readonly ILogger<HorarioDetalleEliminarHandler> logger;

    public HorarioDetalleEliminarHandler(IHorarioDetalleRepository repository, ILogger<HorarioDetalleEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Unit> Handle(HorarioDetalleEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.Eliminar(request.Id);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar el detalle {Id}", request.Id);
            throw;
        }
    }
}
