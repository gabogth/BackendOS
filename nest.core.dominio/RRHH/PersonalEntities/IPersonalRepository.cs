namespace nest.core.dominio.RRHH.PersonalEntities
{
    public interface IPersonalRepository
    {
        Task<Personal> ObtenerPorId(int id);
        Task<List<Personal>> ObtenerTodos();
        Task<List<Personal>> ObtenerActivos();
        Task<Personal> Agregar(PersonalCrearDto entry);
        Task<Personal> Modificar(int id, PersonalCrearDto entry);
        Task Eliminar(int id);
    }
}
