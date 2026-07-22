using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalEstados.Queries;
using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Handlers;

public class ObtenerPersonalEstadosPorFiltroActivosHandler : IRequestHandler<ObtenerPersonalEstadosPorFiltroActivosQuery, LoadResult>
{
    private readonly IPersonalEstadoRepository repository;
    private readonly ILogger<ObtenerPersonalEstadosPorFiltroActivosHandler> logger;

    public ObtenerPersonalEstadosPorFiltroActivosHandler(IPersonalEstadoRepository repository, ILogger<ObtenerPersonalEstadosPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerPersonalEstadosPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los estados de personal activos por filtro datasource");
            throw;
        }
    }
}
