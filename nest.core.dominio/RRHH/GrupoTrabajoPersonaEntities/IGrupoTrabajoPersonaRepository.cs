namespace nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities
{
    public interface IGrupoTrabajoPersonaRepository
    {
        Task<GrupoTrabajoPersona> ObtenerPorId(long id);
        Task<List<GrupoTrabajoPersona>> ObtenerTodos();
        Task<List<GrupoTrabajoPersona>> ObtenerPorGrupoTrabajo(long grupoTrabajoId);
        Task<GrupoTrabajoPersona> Agregar(GrupoTrabajoPersonaCrearDto entry);
        Task<GrupoTrabajoPersona[]> AgregarRange(GrupoTrabajoPersonaCrearDto[] entries);
        Task<GrupoTrabajoPersona> Modificar(long id, GrupoTrabajoPersonaCrearDto entry);
        Task<GrupoTrabajoPersona[]> ModificarRange((long id, GrupoTrabajoPersonaCrearDto entry)[] entries);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
        Task<GrupoTrabajoPersona[]> FusionarRange(GrupoTrabajoPersona[] original, (long id, GrupoTrabajoPersonaCrearDto entry)[] entries);
    }
}
