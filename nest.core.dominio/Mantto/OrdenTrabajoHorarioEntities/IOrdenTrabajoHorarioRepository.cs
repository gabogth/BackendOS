namespace nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities
{
    public interface IOrdenTrabajoHorarioRepository
    {
        Task<OrdenTrabajoHorario> ObtenerPorId(long id);
        Task<List<OrdenTrabajoHorario>> ObtenerTodos();
        Task<List<OrdenTrabajoHorario>> ObtenerPorIds(List<long> ids);
        Task<List<OrdenTrabajoHorario>> ObtenerPorOtYRangoFechas(long OrdenTrabajoCabeceraId, DateOnly Inicio, DateOnly Fin);
        Task<OrdenTrabajoHorario> ObtenerPorPersonalYFecha(int personaId, DateTime fecha);
        Task<List<OrdenTrabajoHorario>> ObtenerCandidatosPorPersonalYFecha(int personaId, DateTime fecha);
        Task<OrdenTrabajoHorario> Agregar(OrdenTrabajoHorario entry);
        Task<OrdenTrabajoHorario[]> Merge(OrdenTrabajoHorario[] current, OrdenTrabajoHorario[] new_entries);
        Task<OrdenTrabajoHorario> Modificar(OrdenTrabajoHorario entry);
        Task Eliminar(long id);
    }
}
