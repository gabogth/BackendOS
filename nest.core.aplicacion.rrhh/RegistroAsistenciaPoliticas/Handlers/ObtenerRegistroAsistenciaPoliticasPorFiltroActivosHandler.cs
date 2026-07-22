using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Queries;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Handlers;

public class ObtenerRegistroAsistenciaPoliticasPorFiltroActivosHandler : IRequestHandler<ObtenerRegistroAsistenciaPoliticasPorFiltroActivosQuery, LoadResult>
{
    private readonly IRegistroAsistenciaPoliticaRepository repository;
    private readonly ILogger<ObtenerRegistroAsistenciaPoliticasPorFiltroActivosHandler> logger;

    public ObtenerRegistroAsistenciaPoliticasPorFiltroActivosHandler(IRegistroAsistenciaPoliticaRepository repository, ILogger<ObtenerRegistroAsistenciaPoliticasPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerRegistroAsistenciaPoliticasPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener las políticas de asistencia activas por filtro datasource");
            throw;
        }
    }
}
