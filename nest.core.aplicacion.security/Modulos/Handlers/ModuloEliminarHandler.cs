using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Modulos.Commands;
using nest.core.dominio.Aplicacion.Modulo;

namespace nest.core.aplicacion.security.Modulos.Handlers;

public class ModuloEliminarHandler : IRequestHandler<ModuloEliminarCommand, Unit>
{
    private readonly IModuloRepository repository;
    private readonly ILogger<ModuloEliminarHandler> logger;

    public ModuloEliminarHandler(IModuloRepository repository, ILogger<ModuloEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Unit> Handle(ModuloEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.Eliminar(request.Id);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar el módulo {Id}", request.Id);
            throw;
        }
    }
}
