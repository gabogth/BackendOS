using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Queries
{
    public record ObtenerPorIdsQuery(List<long> Ids) : IRequest<List<OrdenTrabajoDetalleActivo>>;
}
