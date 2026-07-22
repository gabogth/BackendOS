using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Handlers;

public class ObtenerRegistroAsistenciaPoliticasPorFiltroDataSourceHandler : IRequestHandler<ObtenerRegistroAsistenciaPoliticasPorFiltroDataSourceQuery, LoadResult>
{
    private readonly IRegistroAsistenciaPoliticaRepository repository;
    private readonly ILogger<ObtenerRegistroAsistenciaPoliticasPorFiltroDataSourceHandler> logger;

    public ObtenerRegistroAsistenciaPoliticasPorFiltroDataSourceHandler(IRegistroAsistenciaPoliticaRepository repository, ILogger<ObtenerRegistroAsistenciaPoliticasPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerRegistroAsistenciaPoliticasPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener las políticas de asistencia por filtro datasource");
            throw;
        }
    }
}
