using System.Collections.Generic;

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
    }
}
