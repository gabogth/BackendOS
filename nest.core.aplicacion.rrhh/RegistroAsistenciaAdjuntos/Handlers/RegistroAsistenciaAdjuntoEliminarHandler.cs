using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Handlers;

public class RegistroAsistenciaAdjuntoEliminarHandler : IRequestHandler<RegistroAsistenciaAdjuntoEliminarCommand, Unit>
{
    private readonly IRegistroAsistenciaAdjuntoRepository repository;
    private readonly ILogger<RegistroAsistenciaAdjuntoEliminarHandler> logger;

    public RegistroAsistenciaAdjuntoEliminarHandler(IRegistroAsistenciaAdjuntoRepository repository, ILogger<RegistroAsistenciaAdjuntoEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Unit> Handle(RegistroAsistenciaAdjuntoEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.Eliminar(request.RegistroAsistenciaId);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar el adjunto del registro de asistencia {Id}", request.RegistroAsistenciaId);
            throw;
        }
    }
}
