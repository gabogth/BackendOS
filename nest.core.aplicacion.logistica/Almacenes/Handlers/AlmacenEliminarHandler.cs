using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.logistica.Almacenes.Commands;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Handlers;

public class AlmacenEliminarHandler : IRequestHandler<AlmacenEliminarCommand>
{
    private readonly IAlmacenRepository repository;
    private readonly ILogger<AlmacenEliminarHandler> logger;

    public AlmacenEliminarHandler(IAlmacenRepository repository, ILogger<AlmacenEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task Handle(AlmacenEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await this.repository.Eliminar(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar el almacén {Id}", request.Id);
            throw;
        }
    }
}
