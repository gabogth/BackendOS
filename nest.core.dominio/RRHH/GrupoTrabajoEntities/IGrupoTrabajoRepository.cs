using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.RRHH.GrupoTrabajoEntities
{
    public interface IGrupoTrabajoRepository
    {
        Task<GrupoTrabajo> ObtenerPorId(long id);
        Task<List<GrupoTrabajo>> ObtenerTodos();
        Task<List<GrupoTrabajo>> ObtenerActivos();
        Task<GrupoTrabajo> Agregar(GrupoTrabajo entidad);
        Task<GrupoTrabajo> Modificar(GrupoTrabajo entidad);
        Task Eliminar(long id);
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
    }
}
