using MediatR;
using nest.core.dominio.General.PaisEntities;

namespace nest.core.aplicacion.general.Features.Paises.Queries;

public record GetPaisesQuery() : IRequest<List<Pais>>;

public class GetPaisesQueryHandler(IPaisRepository repository)
    : IRequestHandler<GetPaisesQuery, List<Pais>>
{
    public Task<List<Pais>> Handle(GetPaisesQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetPaisByIdQuery(int Id) : IRequest<Pais>;

public class GetPaisByIdQueryHandler(IPaisRepository repository)
    : IRequestHandler<GetPaisByIdQuery, Pais>
{
    public Task<Pais> Handle(GetPaisByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}

public record GetPaisesActivosQuery() : IRequest<List<Pais>>;

public class GetPaisesActivosQueryHandler(IPaisRepository repository)
    : IRequestHandler<GetPaisesActivosQuery, List<Pais>>
{
    public Task<List<Pais>> Handle(GetPaisesActivosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerActivos();
}
