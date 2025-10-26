using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Queries
{
    public record ObtenerPorDetalleQuery(long OrdenTrabajoDetalleId) : IRequest<List<OrdenTrabajoDetalleActivo>>;
}
