using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Queries
{
    public sealed record ObtenerTodosSimplificadoQuery : IRequest<List<OrdenTrabajoCabeceraQueryView>>, IQueryBase;
}
