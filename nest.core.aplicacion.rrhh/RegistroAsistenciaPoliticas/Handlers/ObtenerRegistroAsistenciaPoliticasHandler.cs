using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Handlers;

public class ObtenerRegistroAsistenciaPoliticasHandler : IRequestHandler<ObtenerRegistroAsistenciaPoliticasQuery, List<RegistroAsistenciaPolitica>>
{
    private readonly IRegistroAsistenciaPoliticaRepository repository;
    private readonly ILogger<ObtenerRegistroAsistenciaPoliticasHandler> logger;

    public ObtenerRegistroAsistenciaPoliticasHandler(IRegistroAsistenciaPoliticaRepository repository, ILogger<ObtenerRegistroAsistenciaPoliticasHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<RegistroAsistenciaPolitica>> Handle(ObtenerRegistroAsistenciaPoliticasQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerTodos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener las políticas de asistencia");
            throw;
        }
    }
}
