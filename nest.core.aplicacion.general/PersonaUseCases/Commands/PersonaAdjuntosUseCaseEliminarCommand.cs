using MediatR;

namespace nest.core.aplicacion.general.PersonaUseCases.Commands
{
    public sealed record PersonaAdjuntosUseCaseEliminarCommand(int Id) : IRequest<Unit>;
}
