namespace nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities
{
    public interface IGrupoTrabajoPersonaRepository
    {
        Task<GrupoTrabajoPersona> ObtenerPorId(long id);
        Task<List<GrupoTrabajoPersona>> ObtenerTodos();
        Task<List<GrupoTrabajoPersona>> ObtenerPorGrupoTrabajo(long grupoTrabajoId);
        Task<GrupoTrabajoPersona> Agregar(GrupoTrabajoPersonaCrearDto entry);
        Task<List<GrupoTrabajoPersona>> AgregarRange(List<GrupoTrabajoPersonaCrearDto> entries);
        Task<GrupoTrabajoPersona> Modificar(long id, GrupoTrabajoPersonaCrearDto entry);
        Task<List<GrupoTrabajoPersona>> ModificarRange(List<(long id, GrupoTrabajoPersonaCrearDto entry)> entries);
        Task Eliminar(long id);
        Task EliminarRange(List<long> ids);
        Task<List<GrupoTrabajoPersona>> FusionarRange(List<GrupoTrabajoPersona> original, List<(long id, GrupoTrabajoPersonaCrearDto entry)> entries);
    }
}
