using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.Distritos.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<Distrito>>, IQueryBase;
}
