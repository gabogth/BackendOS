using System.Collections.Generic;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities
{
    public interface IRegistroAsistenciaOrdenTrabajoRepository
    {
        Task<RegistroAsistenciaOrdenTrabajo> ObtenerPorId(long id);
        Task<List<RegistroAsistenciaOrdenTrabajo>> ObtenerTodos();
        Task<RegistroAsistenciaOrdenTrabajo> Agregar(RegistroAsistenciaOrdenTrabajo entidad);
        Task<RegistroAsistenciaOrdenTrabajo> Modificar(RegistroAsistenciaOrdenTrabajo entidad);
        Task Eliminar(long id);
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
    }
}
