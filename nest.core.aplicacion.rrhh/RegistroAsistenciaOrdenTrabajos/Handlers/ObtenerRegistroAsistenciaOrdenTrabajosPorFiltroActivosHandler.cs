using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Handlers;

public class ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroActivosHandler : IRequestHandler<ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroActivosQuery, LoadResult>
{
    private readonly IRegistroAsistenciaOrdenTrabajoRepository repository;
    private readonly ILogger<ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroActivosHandler> logger;

    public ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroActivosHandler(IRegistroAsistenciaOrdenTrabajoRepository repository, ILogger<ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los registros de asistencia-orden de trabajo activos por filtro datasource");
            throw;
        }
    }
}
