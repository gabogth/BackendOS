namespace nest.core.dominio.General.DistritoEntities
{
    public interface IDistritoRepository
    {
        Task<Distrito> ObtenerPorId(int id);
        Task<List<Distrito>> ObtenerTodos();
        Task<Distrito> Agregar(DistritoCrearDto entry);
        Task<Distrito> Modificar(int id, DistritoCrearDto entry);
        Task Eliminar(int id);
    }
}
