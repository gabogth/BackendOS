using MediatR;
using nest.core.aplicacion.logistica.Almacenes.Queries;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Handlers;

public class ObtenerAlmacenesHandler : IRequestHandler<ObtenerAlmacenesQuery, List<Almacen>>
{
    private readonly IAlmacenRepository repository;

    public ObtenerAlmacenesHandler(IAlmacenRepository repository)
    {
        this.repository = repository;
    }

    public Task<List<Almacen>> Handle(ObtenerAlmacenesQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}
