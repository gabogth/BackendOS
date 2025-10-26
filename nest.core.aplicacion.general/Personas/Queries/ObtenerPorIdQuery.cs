using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Queries
{
    public sealed record ObtenerPorIdQuery(
        int Id
    ) : IRequest<Persona>, IQueryBase;
}
