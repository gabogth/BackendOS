using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.AdjuntoEntities;

namespace nest.core.aplicacion.general.Adjuntos.Queries
{
    public sealed record ObtenerPorIdQuery(long Id) : IRequest<Adjunto>, IQueryBase;
}
