using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicio.Queries
{
    public sealed record ObtenerPorIdQuery(long Id)
        : IRequest<OrdenServicioCabecera>, IQueryBase;
}
