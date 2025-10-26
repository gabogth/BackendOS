using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Handlers;

public class RegistroAsistenciaPoliticaEliminarHandler : IRequestHandler<RegistroAsistenciaPoliticaEliminarCommand, Unit>
{
    private readonly IRegistroAsistenciaPoliticaRepository repository;
    private readonly ILogger<RegistroAsistenciaPoliticaEliminarHandler> logger;

    public RegistroAsistenciaPoliticaEliminarHandler(IRegistroAsistenciaPoliticaRepository repository, ILogger<RegistroAsistenciaPoliticaEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Unit> Handle(RegistroAsistenciaPoliticaEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.Eliminar(request.Id);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar la política de asistencia {Id}", request.Id);
            throw;
        }
    }
}
