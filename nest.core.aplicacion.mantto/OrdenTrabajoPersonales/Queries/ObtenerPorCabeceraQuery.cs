using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Queries
{
    public record ObtenerPorCabeceraQuery(long OrdenTrabajoCabeceraId) : IRequest<List<OrdenTrabajoPersonal>>;
}
