using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Handlers;

internal class ObtenerTodosHandler : IRequestHandler<ObtenerTodosQuery, List<RegistroAsistenciaAdjunto>>
{
    private readonly IRegistroAsistenciaAdjuntoRepository repository;
    private readonly ILogger<ObtenerTodosHandler> logger;

    public ObtenerTodosHandler(IRegistroAsistenciaAdjuntoRepository repository, ILogger<ObtenerTodosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<RegistroAsistenciaAdjunto>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerTodos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los adjuntos de registro de asistencia");
            throw;
        }
    }
}
