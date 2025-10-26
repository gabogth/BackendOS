using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Queries
{
    public record ObtenerPorCabeceraQuery(long OrdenTrabajoCabeceraId) : IRequest<List<OrdenTrabajoDetalle>>;
}
