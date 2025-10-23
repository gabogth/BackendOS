using MediatR;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Features.Distritos.Queries;

public record GetDistritosQuery() : IRequest<List<Distrito>>;

public class GetDistritosQueryHandler(IDistritoRepository repository)
    : IRequestHandler<GetDistritosQuery, List<Distrito>>
{
    public Task<List<Distrito>> Handle(GetDistritosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetDistritoByIdQuery(int Id) : IRequest<Distrito>;

public class GetDistritoByIdQueryHandler(IDistritoRepository repository)
    : IRequestHandler<GetDistritoByIdQuery, Distrito>
{
    public Task<Distrito> Handle(GetDistritoByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}
