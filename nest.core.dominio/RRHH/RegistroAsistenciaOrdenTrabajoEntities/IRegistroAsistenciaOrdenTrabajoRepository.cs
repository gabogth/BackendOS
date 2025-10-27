using System.Collections.Generic;
using System.Threading.Tasks;

namespace nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities
{
    public interface IRegistroAsistenciaOrdenTrabajoRepository
    {
        Task<RegistroAsistenciaOrdenTrabajo> ObtenerPorId(long id);
        Task<List<RegistroAsistenciaOrdenTrabajo>> ObtenerTodos();
        Task<RegistroAsistenciaOrdenTrabajo> Agregar(RegistroAsistenciaOrdenTrabajo entidad);
        Task<RegistroAsistenciaOrdenTrabajo> Modificar(RegistroAsistenciaOrdenTrabajo entidad);
        Task Eliminar(long id);
    }
}
