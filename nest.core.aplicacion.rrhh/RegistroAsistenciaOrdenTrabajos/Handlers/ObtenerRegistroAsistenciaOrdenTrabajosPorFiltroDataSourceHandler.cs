using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Handlers;

public class ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroDataSourceHandler : IRequestHandler<ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroDataSourceQuery, LoadResult>
{
    private readonly IRegistroAsistenciaOrdenTrabajoRepository repository;
    private readonly ILogger<ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroDataSourceHandler> logger;

    public ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroDataSourceHandler(IRegistroAsistenciaOrdenTrabajoRepository repository, ILogger<ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerRegistroAsistenciaOrdenTrabajosPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los registros de asistencia-orden de trabajo por filtro datasource");
            throw;
        }
    }
}
