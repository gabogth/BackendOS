using MediatR;
using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.aplicacion.general.Features.Provincias.Queries;

public record GetProvinciasQuery() : IRequest<List<Provincia>>;

public class GetProvinciasQueryHandler(IProvinciaRepository repository)
    : IRequestHandler<GetProvinciasQuery, List<Provincia>>
{
    public Task<List<Provincia>> Handle(GetProvinciasQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetProvinciaByIdQuery(int Id) : IRequest<Provincia>;

public class GetProvinciaByIdQueryHandler(IProvinciaRepository repository)
    : IRequestHandler<GetProvinciaByIdQuery, Provincia>
{
    public Task<Provincia> Handle(GetProvinciaByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}
