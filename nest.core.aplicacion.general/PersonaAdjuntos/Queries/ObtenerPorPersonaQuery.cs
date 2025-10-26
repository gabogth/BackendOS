using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Queries
{
    public sealed record ObtenerPorPersonaQuery(
        int PersonaId
    ) : IRequest<List<PersonaAdjunto>>, IQueryBase;
}
