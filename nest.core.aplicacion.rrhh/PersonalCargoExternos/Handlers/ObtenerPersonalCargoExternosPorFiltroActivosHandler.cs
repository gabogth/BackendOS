using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.PersonalCargoExternos.Queries;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Handlers;

public class ObtenerPersonalCargoExternosPorFiltroActivosHandler : IRequestHandler<ObtenerPersonalCargoExternosPorFiltroActivosQuery, LoadResult>
{
    private readonly IPersonalCargoExternoRepository repository;
    private readonly ILogger<ObtenerPersonalCargoExternosPorFiltroActivosHandler> logger;

    public ObtenerPersonalCargoExternosPorFiltroActivosHandler(IPersonalCargoExternoRepository repository, ILogger<ObtenerPersonalCargoExternosPorFiltroActivosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<LoadResult> Handle(ObtenerPersonalCargoExternosPorFiltroActivosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerFilterActivos(request.options, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los cargos externos activos por filtro datasource");
            throw;
        }
    }
}
