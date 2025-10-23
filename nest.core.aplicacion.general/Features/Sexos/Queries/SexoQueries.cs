using MediatR;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Features.Sexos.Queries;

public record GetSexosQuery() : IRequest<List<Sexo>>;

public class GetSexosQueryHandler(ISexoRepository repository)
    : IRequestHandler<GetSexosQuery, List<Sexo>>
{
    public Task<List<Sexo>> Handle(GetSexosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetSexoByIdQuery(byte Id) : IRequest<Sexo>;

public class GetSexoByIdQueryHandler(ISexoRepository repository)
    : IRequestHandler<GetSexoByIdQuery, Sexo>
{
    public Task<Sexo> Handle(GetSexoByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}

public record GetSexosActivosQuery() : IRequest<List<Sexo>>;

public class GetSexosActivosQueryHandler(ISexoRepository repository)
    : IRequestHandler<GetSexosActivosQuery, List<Sexo>>
{
    public Task<List<Sexo>> Handle(GetSexosActivosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerActivos();
}
