using MediatR;
using nest.core.aplicacion.logistica.Almacenes.Queries;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Handlers;

public class ObtenerAlmacenPorIdHandler : IRequestHandler<ObtenerAlmacenPorIdQuery, Almacen>
{
    private readonly IAlmacenRepository repository;

    public ObtenerAlmacenPorIdHandler(IAlmacenRepository repository)
    {
        this.repository = repository;
    }

    public Task<Almacen> Handle(ObtenerAlmacenPorIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}
