using System.Linq;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Modulos.Queries;
using nest.core.dominio.Aplicacion.Modulo;

namespace nest.core.aplicacion.security.Modulos.Handlers;

public class ObtenerModulosPorFiltroHandler : IRequestHandler<ObtenerModulosPorFiltroQuery, List<Modulo>>
{
    private readonly IModuloRepository repository;
    private readonly ILogger<ObtenerModulosPorFiltroHandler> logger;

    public ObtenerModulosPorFiltroHandler(IModuloRepository repository, ILogger<ObtenerModulosPorFiltroHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<Modulo>> Handle(ObtenerModulosPorFiltroQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorUnaPropiedad(request.Filtros.ToDictionary(k => k.Key, v => v.Value));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los módulos por filtro");
            throw;
        }
    }
}
