using MediatR;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.Features.PersonaAdjuntos.Queries;

public record GetPersonaAdjuntosQuery() : IRequest<List<PersonaAdjunto>>;

public class GetPersonaAdjuntosQueryHandler(IPersonaAdjuntoRepository repository)
    : IRequestHandler<GetPersonaAdjuntosQuery, List<PersonaAdjunto>>
{
    public Task<List<PersonaAdjunto>> Handle(GetPersonaAdjuntosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetPersonaAdjuntoByIdQuery(long Id) : IRequest<PersonaAdjunto>;

public class GetPersonaAdjuntoByIdQueryHandler(IPersonaAdjuntoRepository repository)
    : IRequestHandler<GetPersonaAdjuntoByIdQuery, PersonaAdjunto>
{
    public Task<PersonaAdjunto> Handle(GetPersonaAdjuntoByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}

public record GetPersonaAdjuntosByPersonaQuery(int PersonaId) : IRequest<List<PersonaAdjunto>>;

public class GetPersonaAdjuntosByPersonaQueryHandler(IPersonaAdjuntoRepository repository)
    : IRequestHandler<GetPersonaAdjuntosByPersonaQuery, List<PersonaAdjunto>>
{
    public Task<List<PersonaAdjunto>> Handle(GetPersonaAdjuntosByPersonaQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorPersona(request.PersonaId);
}
