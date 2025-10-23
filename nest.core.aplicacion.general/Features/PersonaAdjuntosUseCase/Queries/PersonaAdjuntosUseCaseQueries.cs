using MediatR;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Features.PersonaAdjuntosUseCase.Queries;

public record GetPersonasConAdjuntosQuery() : IRequest<List<Persona>>;

public class GetPersonasConAdjuntosQueryHandler(IPersonaAdjuntosUseCaseRepository repository)
    : IRequestHandler<GetPersonasConAdjuntosQuery, List<Persona>>
{
    public Task<List<Persona>> Handle(GetPersonasConAdjuntosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetPersonaConAdjuntosByIdQuery(int Id) : IRequest<Persona>;

public class GetPersonaConAdjuntosByIdQueryHandler(IPersonaAdjuntosUseCaseRepository repository)
    : IRequestHandler<GetPersonaConAdjuntosByIdQuery, Persona>
{
    public Task<Persona> Handle(GetPersonaConAdjuntosByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}
