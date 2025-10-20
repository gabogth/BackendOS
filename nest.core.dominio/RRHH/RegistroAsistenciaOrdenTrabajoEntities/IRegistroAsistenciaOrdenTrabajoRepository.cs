using System.Collections.Generic;
using System.Threading.Tasks;

namespace nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities
{
    public interface IRegistroAsistenciaOrdenTrabajoRepository
    {
        Task<RegistroAsistenciaOrdenTrabajo> ObtenerPorId(long id);
        Task<List<RegistroAsistenciaOrdenTrabajo>> ObtenerTodos();
        Task<RegistroAsistenciaOrdenTrabajo> Agregar(RegistroAsistenciaOrdenTrabajoCrearDto entidad);
        Task<RegistroAsistenciaOrdenTrabajo> Modificar(long id, RegistroAsistenciaOrdenTrabajoCrearDto entidad);
        Task Eliminar(long id);
    }
}
