using MediatR;
using nest.core.dominio.General.AdjuntoEntities;

namespace nest.core.aplicacion.general.Features.Adjuntos.Queries;

public record GetAdjuntosQuery() : IRequest<List<Adjunto>>;

public class GetAdjuntosQueryHandler(IAdjuntoRepository repository)
    : IRequestHandler<GetAdjuntosQuery, List<Adjunto>>
{
    public Task<List<Adjunto>> Handle(GetAdjuntosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetAdjuntoByIdQuery(long Id) : IRequest<Adjunto>;

public class GetAdjuntoByIdQueryHandler(IAdjuntoRepository repository)
    : IRequestHandler<GetAdjuntoByIdQuery, Adjunto>
{
    public Task<Adjunto> Handle(GetAdjuntoByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}
