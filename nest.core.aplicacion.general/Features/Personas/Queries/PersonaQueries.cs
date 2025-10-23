using MediatR;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Features.Personas.Queries;

public record GetPersonasQuery() : IRequest<List<Persona>>;

public class GetPersonasQueryHandler(IPersonaRepository repository)
    : IRequestHandler<GetPersonasQuery, List<Persona>>
{
    public Task<List<Persona>> Handle(GetPersonasQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetPersonaByIdQuery(int Id) : IRequest<Persona>;

public class GetPersonaByIdQueryHandler(IPersonaRepository repository)
    : IRequestHandler<GetPersonaByIdQuery, Persona>
{
    public Task<Persona> Handle(GetPersonaByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}

public record GetPersonasActivasQuery() : IRequest<List<Persona>>;

public class GetPersonasActivasQueryHandler(IPersonaRepository repository)
    : IRequestHandler<GetPersonasActivasQuery, List<Persona>>
{
    public Task<List<Persona>> Handle(GetPersonasActivasQuery request, CancellationToken cancellationToken)
        => repository.ObtenerActivos();
}
