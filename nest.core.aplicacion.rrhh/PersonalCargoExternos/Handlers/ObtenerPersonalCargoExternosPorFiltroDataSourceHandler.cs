using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Queries;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Handlers;

public class ObtenerPersonalCargoExternosPorFiltroDataSourceHandler : IRequestHandler<ObtenerPersonalCargoExternosPorFiltroDataSourceQuery, LoadResult>
{
    private readonly IPersonalCargoExternoRepository repository;
    private readonly ILogger<ObtenerPersonalCargoExternosPorFiltroDataSourceHandler> logger;

    public ObtenerPersonalCargoExternosPorFiltroDataSourceHandler(IPersonalCargoExternoRepository repository, ILogger<ObtenerPersonalCargoExternosPorFiltroDataSourceHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerPersonalCargoExternosPorFiltroDataSourceQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilter(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los cargos externos por filtro datasource");
            throw;
        }
    }
}
