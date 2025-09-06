namespace nest.core.dominio.Finanzas.MonedaEntities
{
    public interface IMonedaRepository
    {
        Task<Moneda> ObtenerPorId(int id);
        Task<List<Moneda>> ObtenerTodos();
        Task<Moneda> Agregar(MonedaCrearDto entidad);
        Task<Moneda> Modificar(int id, MonedaCrearDto entidad);
        Task Eliminar(int id);
    }
}
