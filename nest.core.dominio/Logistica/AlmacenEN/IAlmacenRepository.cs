namespace nest.core.dominio.Logistica.AlmacenEN
{
    public interface IAlmacenRepository
    {
        Task<Almacen> ObtenerPorId(int id);
        Task<List<Almacen>> ObtenerTodos();
        Task<List<Almacen>> ObtenerActivos();
        Task<Almacen> Agregar(Almacen entry);
        Task<Almacen> Modificar(Almacen entry);
        Task Eliminar(int id);
    }
}
