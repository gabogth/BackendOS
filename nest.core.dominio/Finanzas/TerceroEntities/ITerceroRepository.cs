namespace nest.core.dominio.Finanzas.ClienteEntities
{
    public interface ITerceroRepository
    {
        Task<Tercero> ObtenerPorId(int id);
        Task<List<Tercero>> ObtenerTodos();
        Task<Tercero> Agregar(TerceroCrearDto entidad);
        Task<Tercero> Modificar(int id, TerceroCrearDto entidad);
        Task Eliminar(int id);
    }
}
