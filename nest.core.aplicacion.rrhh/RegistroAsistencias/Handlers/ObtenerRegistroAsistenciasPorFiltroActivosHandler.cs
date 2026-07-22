using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers;

public class ObtenerRegistroAsistenciasPorFiltroActivosHandler : IRequestHandler<ObtenerRegistroAsistenciasPorFiltroActivosQuery, LoadResult>
{
    private readonly IRegistroAsistenciaRepository repository;
    private readonly ILogger<ObtenerRegistroAsistenciasPorFiltroActivosHandler> logger;

    public ObtenerRegistroAsistenciasPorFiltroActivosHandler(IRegistroAsistenciaRepository repository, ILogger<ObtenerRegistroAsistenciasPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerRegistroAsistenciasPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los registros de asistencia activos por filtro datasource");
            throw;
        }
    }
}
