namespace nest.core.dominio.General.DistritoEntities
{
    public interface IDistritoRepository
    {
        Task<Distrito> ObtenerPorId(int id);
        Task<List<Distrito>> ObtenerTodos();
        Task<Distrito> Agregar(Distrito entry);
        Task<Distrito> Modificar(Distrito entry);
        Task Eliminar(int id);
    }
}
