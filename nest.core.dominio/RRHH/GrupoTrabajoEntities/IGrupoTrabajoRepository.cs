using System.Collections.Generic;

namespace nest.core.dominio.RRHH.GrupoTrabajoEntities
{
    public interface IGrupoTrabajoRepository
    {
        Task<GrupoTrabajo> ObtenerPorId(long id);
        Task<List<GrupoTrabajo>> ObtenerTodos();
        Task<List<GrupoTrabajo>> ObtenerActivos();
        Task<GrupoTrabajo> Agregar(GrupoTrabajoCrearDto entry);
        Task<GrupoTrabajo> Modificar(long id, GrupoTrabajoCrearDto entidad);
        Task Eliminar(long id);
    }
}
