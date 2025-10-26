using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.AdjuntoTipos.Queries
{
    public sealed record ObtenerActivosQuery : IRequest<List<AdjuntoTipo>>, IQueryBase;
}
