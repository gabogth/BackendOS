namespace nest.core.dominio.Costos.CentroDeCostosEntities
{
    public interface ICentroDeCostosRepository
    {
        Task<CentroDeCostos> ObtenerPorId(int id);
        Task<List<CentroDeCostos>> ObtenerTodos();
        Task<List<CentroDeCostos>> ObtenerActivos();
        Task<CentroDeCostos> Agregar(CentroDeCostos entry);
        Task<CentroDeCostos> Modificar(CentroDeCostos entry);
        Task Eliminar(int id);
    }
}
