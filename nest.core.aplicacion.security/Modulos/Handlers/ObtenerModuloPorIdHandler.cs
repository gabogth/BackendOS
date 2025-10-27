using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Modulos.Queries;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Aplicacion.Modulo.Repository;

namespace nest.core.aplicacion.security.Modulos.Handlers;

public class ObtenerModuloPorIdHandler : IRequestHandler<ObtenerModuloPorIdQuery, Modulo>
{
    private readonly IModuloRepository repository;
    private readonly ILogger<ObtenerModuloPorIdHandler> logger;

    public ObtenerModuloPorIdHandler(IModuloRepository repository, ILogger<ObtenerModuloPorIdHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Modulo> Handle(ObtenerModuloPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.ObtenerPorId(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al obtener el módulo {Id}", request.Id);
            throw;
        }
    }
}
