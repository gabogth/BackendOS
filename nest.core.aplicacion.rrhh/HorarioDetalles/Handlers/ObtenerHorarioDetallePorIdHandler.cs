using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.HorarioDetalles.Queries;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Handlers;

public class ObtenerHorarioDetallePorIdHandler : IRequestHandler<ObtenerHorarioDetallePorIdQuery, HorarioDetalle>
{
    private readonly IHorarioDetalleRepository repository;
    private readonly ILogger<ObtenerHorarioDetallePorIdHandler> logger;

    public ObtenerHorarioDetallePorIdHandler(IHorarioDetalleRepository repository, ILogger<ObtenerHorarioDetallePorIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<HorarioDetalle> Handle(ObtenerHorarioDetallePorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorId(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el detalle {Id}", request.Id);
            throw;
        }
    }
}
