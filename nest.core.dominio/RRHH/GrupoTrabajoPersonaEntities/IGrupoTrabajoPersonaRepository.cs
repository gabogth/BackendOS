namespace nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities
{
    public interface IGrupoTrabajoPersonaRepository
    {
        Task<GrupoTrabajoPersona> ObtenerPorId(long id);
        Task<List<GrupoTrabajoPersona>> ObtenerTodos();
        Task<List<GrupoTrabajoPersona>> ObtenerPorGrupoTrabajo(long grupoTrabajoId);
        Task<GrupoTrabajoPersona> Agregar(GrupoTrabajoPersonaCrearDto entry);
        Task<GrupoTrabajoPersona> Modificar(long id, GrupoTrabajoPersonaCrearDto entry);
        Task Eliminar(long id);
    }
}
