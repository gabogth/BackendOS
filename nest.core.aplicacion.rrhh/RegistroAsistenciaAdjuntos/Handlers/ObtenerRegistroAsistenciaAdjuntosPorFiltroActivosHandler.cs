using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Handlers;

public class ObtenerRegistroAsistenciaAdjuntosPorFiltroActivosHandler : IRequestHandler<ObtenerRegistroAsistenciaAdjuntosPorFiltroActivosQuery, LoadResult>
{
    private readonly IRegistroAsistenciaAdjuntoRepository repository;
    private readonly ILogger<ObtenerRegistroAsistenciaAdjuntosPorFiltroActivosHandler> logger;

    public ObtenerRegistroAsistenciaAdjuntosPorFiltroActivosHandler(IRegistroAsistenciaAdjuntoRepository repository, ILogger<ObtenerRegistroAsistenciaAdjuntosPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerRegistroAsistenciaAdjuntosPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los adjuntos de asistencia activos por filtro datasource");
            throw;
        }
    }
}
