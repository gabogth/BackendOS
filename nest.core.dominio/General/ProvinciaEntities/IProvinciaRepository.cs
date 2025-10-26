namespace nest.core.dominio.General.ProvinciaEntities
{
    public interface IProvinciaRepository
    {
        Task<Provincia> ObtenerPorId(int id);
        Task<List<Provincia>> ObtenerTodos();
        Task<List<Provincia>> ObtenerActivos();
        Task<Provincia> Agregar(Provincia entry);
        Task<Provincia> Modificar(Provincia entry);
        Task Eliminar(int id);
    }
}
