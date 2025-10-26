namespace nest.core.dominio.Finanzas.MonedaEntities
{
    public interface IMonedaRepository
    {
        Task<Moneda> ObtenerPorId(int id);
        Task<List<Moneda>> ObtenerTodos();
        Task<Moneda> Agregar(Moneda entry);
        Task<Moneda> Modificar(Moneda entry);
        Task Eliminar(int id);
    }
}
