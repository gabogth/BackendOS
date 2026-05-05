using MediatR;
using nest.core.aplicacion.logistica.Almacenes.Queries;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Handlers;

public class ObtenerAlmacenesActivosHandler : IRequestHandler<ObtenerAlmacenesActivosQuery, List<Almacen>>
{
    private readonly IAlmacenRepository repository;

    public ObtenerAlmacenesActivosHandler(IAlmacenRepository repository)
    {
        this.repository = repository;
    }

    public Task<List<Almacen>> Handle(ObtenerAlmacenesActivosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerActivos();
}
