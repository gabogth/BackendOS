using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Personas.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<Persona>>, IQueryBase;
}
