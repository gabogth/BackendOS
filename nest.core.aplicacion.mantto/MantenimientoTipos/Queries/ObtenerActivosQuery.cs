using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;

namespace nest.core.aplicacion.mantto.MantenimientoTipos.Queries
{
    public sealed record ObtenerActivosQuery : IRequest<List<MantenimientoTipo>>, IQueryBase;
}
