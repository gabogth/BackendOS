using MediatR;
using nest.core.aplicacion.logistica.Almacenes.Commands;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Handlers;

public class AlmacenEliminarHandler : IRequestHandler<AlmacenEliminarCommand>
{
    private readonly IAlmacenRepository repository;

    public AlmacenEliminarHandler(IAlmacenRepository repository)
    {
        this.repository = repository;
    }

    public async Task Handle(AlmacenEliminarCommand request, CancellationToken cancellationToken)
        => await repository.Eliminar(request.Id);
}
