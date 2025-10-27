using MediatR;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.PersonaUseCases.Queries
{
    public sealed record ObtenerPersonaConAdjuntosPorIdQuery(int Id) : IRequest<Persona>;
}
