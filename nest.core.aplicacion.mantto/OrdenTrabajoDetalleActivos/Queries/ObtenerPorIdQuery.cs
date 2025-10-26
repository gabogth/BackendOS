using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Queries
{
    public record ObtenerPorIdQuery(long Id) : IRequest<OrdenTrabajoDetalleActivo>;
}
