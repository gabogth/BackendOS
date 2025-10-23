using MediatR;
using nest.core.dominio.General.DepartamentoEntites;

namespace nest.core.aplicacion.general.Features.Departamentos.Queries;

public record GetDepartamentosQuery() : IRequest<List<Departamento>>;

public class GetDepartamentosQueryHandler(IDepartamentoRepository repository)
    : IRequestHandler<GetDepartamentosQuery, List<Departamento>>
{
    public Task<List<Departamento>> Handle(GetDepartamentosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetDepartamentoByIdQuery(int Id) : IRequest<Departamento>;

public class GetDepartamentoByIdQueryHandler(IDepartamentoRepository repository)
    : IRequestHandler<GetDepartamentoByIdQuery, Departamento>
{
    public Task<Departamento> Handle(GetDepartamentoByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}
