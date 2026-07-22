using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers;

public class ObtenerRegistroAsistenciasPorFiltroDataSourceHandler : IRequestHandler<ObtenerRegistroAsistenciasPorFiltroDataSourceQuery, LoadResult>
{
    private readonly IRegistroAsistenciaRepository repository;
    private readonly ILogger<ObtenerRegistroAsistenciasPorFiltroDataSourceHandler> logger;

    public ObtenerRegistroAsistenciasPorFiltroDataSourceHandler(IRegistroAsistenciaRepository repository, ILogger<ObtenerRegistroAsistenciasPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerRegistroAsistenciasPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los registros de asistencia por filtro datasource");
            throw;
        }
    }
}
