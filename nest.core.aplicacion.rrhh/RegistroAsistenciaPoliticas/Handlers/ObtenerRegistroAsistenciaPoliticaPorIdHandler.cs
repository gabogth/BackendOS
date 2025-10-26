using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Handlers;

public class ObtenerRegistroAsistenciaPoliticaPorIdHandler : IRequestHandler<ObtenerRegistroAsistenciaPoliticaPorIdQuery, RegistroAsistenciaPolitica>
{
    private readonly IRegistroAsistenciaPoliticaRepository repository;
    private readonly ILogger<ObtenerRegistroAsistenciaPoliticaPorIdHandler> logger;

    public ObtenerRegistroAsistenciaPoliticaPorIdHandler(IRegistroAsistenciaPoliticaRepository repository, ILogger<ObtenerRegistroAsistenciaPoliticaPorIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<RegistroAsistenciaPolitica> Handle(ObtenerRegistroAsistenciaPoliticaPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorId(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener la política de asistencia {Id}", request.Id);
            throw;
        }
    }
}
