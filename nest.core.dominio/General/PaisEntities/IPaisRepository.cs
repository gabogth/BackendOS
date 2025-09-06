namespace nest.core.dominio.General.PaisEntities
{
    public interface IPaisRepository
    {
        Task<Pais> ObtenerPorId(int id);
        Task<List<Pais>> ObtenerTodos();
        Task<List<Pais>> ObtenerActivos();
        Task<Pais> Agregar(PaisCrearDto entry);
        Task<Pais> Modificar(int id, PaisCrearDto entry);
        Task Eliminar(int id);
    }
}
