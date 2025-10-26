using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.AdjuntoEntities;

namespace nest.core.aplicacion.general.Adjuntos.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<Adjunto>>, IQueryBase;
}
