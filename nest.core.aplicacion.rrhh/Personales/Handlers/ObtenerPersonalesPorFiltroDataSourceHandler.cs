using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Personales.Queries;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Handlers;

public class ObtenerPersonalesPorFiltroDataSourceHandler : IRequestHandler<ObtenerPersonalesPorFiltroDataSourceQuery, LoadResult>
{
    private readonly IPersonalRepository repository;
    private readonly ILogger<ObtenerPersonalesPorFiltroDataSourceHandler> logger;

    public ObtenerPersonalesPorFiltroDataSourceHandler(IPersonalRepository repository, ILogger<ObtenerPersonalesPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerPersonalesPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el personal por filtro datasource");
            throw;
        }
    }
}
