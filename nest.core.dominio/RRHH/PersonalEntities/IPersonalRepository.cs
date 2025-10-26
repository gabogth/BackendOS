namespace nest.core.dominio.RRHH.PersonalEntities
{
    public interface IPersonalRepository
    {
        Task<Personal> ObtenerPorId(int id);
        Task<List<Personal>> ObtenerTodos();
        Task<List<Personal>> ObtenerActivos();
        Task<Personal> Agregar(Personal entry);
        Task<Personal> Modificar(Personal entry);
        Task Eliminar(int id);
    }
}
