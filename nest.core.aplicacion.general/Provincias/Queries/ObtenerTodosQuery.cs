using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.aplicacion.general.Provincias.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<Provincia>>, IQueryBase;
}
