namespace nest.core.dominio.Finanzas.ClienteEntities
{
    public interface ITerceroRepository
    {
        Task<Tercero> ObtenerPorId(int id);
        Task<List<Tercero>> ObtenerTodos();
        Task<Tercero> Agregar(Tercero entidad);
        Task<Tercero> Modificar(Tercero entidad);
        Task Eliminar(int id);
    }
}
