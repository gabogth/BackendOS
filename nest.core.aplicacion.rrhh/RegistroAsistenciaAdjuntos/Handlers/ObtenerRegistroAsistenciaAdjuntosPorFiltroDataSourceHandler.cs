using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Handlers;

public class ObtenerRegistroAsistenciaAdjuntosPorFiltroDataSourceHandler : IRequestHandler<ObtenerRegistroAsistenciaAdjuntosPorFiltroDataSourceQuery, LoadResult>
{
    private readonly IRegistroAsistenciaAdjuntoRepository repository;
    private readonly ILogger<ObtenerRegistroAsistenciaAdjuntosPorFiltroDataSourceHandler> logger;

    public ObtenerRegistroAsistenciaAdjuntosPorFiltroDataSourceHandler(IRegistroAsistenciaAdjuntoRepository repository, ILogger<ObtenerRegistroAsistenciaAdjuntosPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerRegistroAsistenciaAdjuntosPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los adjuntos de asistencia por filtro datasource");
            throw;
        }
    }
}
