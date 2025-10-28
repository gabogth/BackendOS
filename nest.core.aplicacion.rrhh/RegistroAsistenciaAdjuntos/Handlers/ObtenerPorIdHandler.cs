using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Handlers;

internal class ObtenerPorIdHandler : IRequestHandler<ObtenerPorIdQuery, RegistroAsistenciaAdjunto>
{
    private readonly IRegistroAsistenciaAdjuntoRepository repository;
    private readonly ILogger<ObtenerPorIdHandler> logger;

    public ObtenerPorIdHandler(IRegistroAsistenciaAdjuntoRepository repository, ILogger<ObtenerPorIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<RegistroAsistenciaAdjunto> Handle(ObtenerPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorId(request.RegistroAsistenciaId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el adjunto del registro de asistencia {Id}", request.RegistroAsistenciaId);
            throw;
        }
    }
}
