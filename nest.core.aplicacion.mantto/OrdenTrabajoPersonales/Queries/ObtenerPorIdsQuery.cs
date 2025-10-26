using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Queries
{
    public record ObtenerPorIdsQuery(List<long> Ids) : IRequest<List<OrdenTrabajoPersonal>>;
}
