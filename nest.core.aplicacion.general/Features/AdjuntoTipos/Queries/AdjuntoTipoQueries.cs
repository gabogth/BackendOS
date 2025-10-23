using MediatR;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.Features.AdjuntoTipos.Queries;

public record GetAdjuntoTiposQuery() : IRequest<List<AdjuntoTipo>>;

public class GetAdjuntoTiposQueryHandler(IAdjuntoTipoRepository repository)
    : IRequestHandler<GetAdjuntoTiposQuery, List<AdjuntoTipo>>
{
    public Task<List<AdjuntoTipo>> Handle(GetAdjuntoTiposQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetAdjuntoTipoByIdQuery(AdjuntoTipoEnum Id) : IRequest<AdjuntoTipo>;

public class GetAdjuntoTipoByIdQueryHandler(IAdjuntoTipoRepository repository)
    : IRequestHandler<GetAdjuntoTipoByIdQuery, AdjuntoTipo>
{
    public Task<AdjuntoTipo> Handle(GetAdjuntoTipoByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}

public record GetAdjuntoTiposActivosQuery() : IRequest<List<AdjuntoTipo>>;

public class GetAdjuntoTiposActivosQueryHandler(IAdjuntoTipoRepository repository)
    : IRequestHandler<GetAdjuntoTiposActivosQuery, List<AdjuntoTipo>>
{
    public Task<List<AdjuntoTipo>> Handle(GetAdjuntoTiposActivosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerActivos();
}
