namespace nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities
{
    public interface IOrdenTrabajoHorarioRepository
    {
        Task<OrdenTrabajoHorario> ObtenerPorId(long id);
        Task<List<OrdenTrabajoHorario>> ObtenerTodos();
        Task<OrdenTrabajoHorario> Agregar(OrdenTrabajoHorario entry);
        Task<OrdenTrabajoHorario> Modificar(OrdenTrabajoHorario entry);
        Task Eliminar(long id);
    }
}
