using MediatR;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.PersonaUseCases.Queries
{
    public sealed record ObtenerPersonasConAdjuntosQuery : IRequest<List<Persona>>;
}
