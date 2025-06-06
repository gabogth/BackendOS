namespace nest.core.dominio.General.ProvinciaEntities
{
    public interface IProvinciaRepository
    {
        Task<Provincia> ObtenerPorId(int id);
        Task<List<Provincia>> ObtenerTodos();
        Task<List<Provincia>> ObtenerActivos();
        Task<Provincia> Agregar(ProvinciaCrearDto entry);
        Task<Provincia> Modificar(int id, ProvinciaCrearDto entry);
        Task Eliminar(int id);
    }
}
