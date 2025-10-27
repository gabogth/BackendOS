using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Modulos.Queries;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Aplicacion.Modulo.Repository;

namespace nest.core.aplicacion.security.Modulos.Handlers;

public class ObtenerModulosHandler : IRequestHandler<ObtenerModulosQuery, List<Modulo>>
{
    private readonly IModuloRepository repository;
    private readonly ILogger<ObtenerModulosHandler> logger;

    public ObtenerModulosHandler(IModuloRepository repository, ILogger<ObtenerModulosHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<Modulo>> Handle(ObtenerModulosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerTodos();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener los módulos");
            throw;
        }
    }
}
