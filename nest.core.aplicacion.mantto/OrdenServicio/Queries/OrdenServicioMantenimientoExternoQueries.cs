using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicio.Queries
{
    public sealed record ObtenerOrdenServicioMantenimientoExternoPorIdQuery(long Id)
        : IRequest<OrdenServicioCabecera>, IQueryBase;

    public sealed record ObtenerOrdenServicioMantenimientoExternoTodosQuery
        : IRequest<List<OrdenServicioCabecera>>, IQueryBase;
}
