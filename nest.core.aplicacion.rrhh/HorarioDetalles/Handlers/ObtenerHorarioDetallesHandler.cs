using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.HorarioDetalles.Queries;
using nest.core.dominio.RRHH.HorarioDetalleEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalles.Handlers;

public class ObtenerHorarioDetallesHandler : IRequestHandler<ObtenerHorarioDetallesQuery, List<HorarioDetalle>>
{
    private readonly IHorarioDetalleRepository repository;
    private readonly ILogger<ObtenerHorarioDetallesHandler> logger;

    public ObtenerHorarioDetallesHandler(IHorarioDetalleRepository repository, ILogger<ObtenerHorarioDetallesHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<HorarioDetalle>> Handle(ObtenerHorarioDetallesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerTodos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los detalles de horario");
            throw;
        }
    }
}
