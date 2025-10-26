using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.AdjuntoTipos.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<AdjuntoTipo>>, IQueryBase;
}
