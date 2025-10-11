using System.Collections.Generic;

namespace nest.core.dominio.RRHH.GrupoTrabajoEntities
{
    public interface IGrupoTrabajoRepository
    {
        Task<GrupoTrabajo> ObtenerPorId(long id);
        Task<List<GrupoTrabajo>> ObtenerTodos();
        Task<List<GrupoTrabajo>> ObtenerActivos();
        Task<GrupoTrabajo> Agregar(GrupoTrabajoDto entidad);
        Task<GrupoTrabajo> Modificar(long id, GrupoTrabajoDto entidad);
        Task Eliminar(long id);
    }
}
