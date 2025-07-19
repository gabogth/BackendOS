namespace nest.core.dominio.Costos.CentroDeCostosEntities
{
    public interface ICentroDeCostosRepository
    {
        Task<CentroDeCostos> ObtenerPorId(int id);
        Task<List<CentroDeCostos>> ObtenerTodos();
        Task<List<CentroDeCostos>> ObtenerActivos();
        Task<CentroDeCostos> Agregar(CentroDeCostosCrearDto entry);
        Task<CentroDeCostos> Modificar(int id, CentroDeCostosCrearDto entry);
        Task Eliminar(int id);
    }
}
