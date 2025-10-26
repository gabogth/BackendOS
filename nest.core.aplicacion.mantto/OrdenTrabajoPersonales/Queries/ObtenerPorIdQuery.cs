using MediatR;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Queries
{
    public record ObtenerPorIdQuery(long Id) : IRequest<OrdenTrabajoPersonal>;
}
