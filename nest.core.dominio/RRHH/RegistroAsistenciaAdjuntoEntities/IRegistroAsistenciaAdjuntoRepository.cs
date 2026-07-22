using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities
{
    public interface IRegistroAsistenciaAdjuntoRepository
    {
        Task<RegistroAsistenciaAdjunto> ObtenerPorId(long id);
        Task<List<RegistroAsistenciaAdjunto>> ObtenerTodos();
        Task<RegistroAsistenciaAdjunto> Agregar(RegistroAsistenciaAdjunto entidad);
        Task<RegistroAsistenciaAdjunto> Modificar(RegistroAsistenciaAdjunto entidad);
        Task Eliminar(long id);
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
    }
}
