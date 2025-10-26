namespace nest.core.dominio.General.PaisEntities
{
    public interface IPaisRepository
    {
        Task<Pais> ObtenerPorId(int id);
        Task<List<Pais>> ObtenerTodos();
        Task<List<Pais>> ObtenerActivos();
        Task<Pais> Agregar(Pais entry);
        Task<Pais> Modificar(Pais entry);
        Task Eliminar(int id);
    }
}
