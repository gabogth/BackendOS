using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalEstados.Queries;
using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.aplicacion.rrhh.PersonalEstados.Handlers;

public class ObtenerPersonalEstadosPorFiltroDataSourceHandler : IRequestHandler<ObtenerPersonalEstadosPorFiltroDataSourceQuery, LoadResult>
{
    private readonly IPersonalEstadoRepository repository;
    private readonly ILogger<ObtenerPersonalEstadosPorFiltroDataSourceHandler> logger;

    public ObtenerPersonalEstadosPorFiltroDataSourceHandler(IPersonalEstadoRepository repository, ILogger<ObtenerPersonalEstadosPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerPersonalEstadosPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los estados de personal por filtro datasource");
            throw;
        }
    }
}
