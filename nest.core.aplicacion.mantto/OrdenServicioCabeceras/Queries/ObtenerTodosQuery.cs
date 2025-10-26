using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceras.Queries
{
    public sealed record ObtenerTodosQuery : IRequest<List<OrdenServicioCabecera>>, IQueryBase;
}
