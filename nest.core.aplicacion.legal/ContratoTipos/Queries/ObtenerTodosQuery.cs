using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Legal.ContratoTipoEntities;

namespace nest.core.aplicacion.legal.ContratoTipos.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<ContratoTipo>>, IQueryBase;
}
