using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<OrdenServicioMantenimientoExterno>>, IQueryBase;
}
