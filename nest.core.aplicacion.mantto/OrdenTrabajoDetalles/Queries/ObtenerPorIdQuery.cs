using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Queries
{
    public record ObtenerPorIdQuery(long Id) : IRequest<OrdenTrabajoDetalle>;
}
