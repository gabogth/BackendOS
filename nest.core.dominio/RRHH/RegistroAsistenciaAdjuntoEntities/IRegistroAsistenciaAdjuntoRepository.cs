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
    }
}
