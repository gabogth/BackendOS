namespace nest.core.dominio.Logistica.AlmacenEN
{
    public interface IAlmacenRepository
    {
        Task<Almacen> ObtenerPorId(int id);
        Task<List<Almacen>> ObtenerTodos();
        Task<List<Almacen>> ObtenerActivos();
        Task<Almacen> Agregar(AlmacenCrearDto entry);
        Task<Almacen> Modificar(int id, AlmacenCrearDto entry);
        Task Eliminar(int id);
    }
}
