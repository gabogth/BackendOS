using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.aplicacion.costos.CentroDeCostosServices
{
    public class CentroDeCostosService
    {
        private readonly ICentroDeCostosRepository repository;

        public CentroDeCostosService(ICentroDeCostosRepository repository)
        {
            this.repository = repository;
        }

        public Task<CentroDeCostos> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<CentroDeCostos>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<CentroDeCostos>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<CentroDeCostos> Agregar(CentroDeCostosCrearDto entry) => repository.Agregar(entry);
        public Task<CentroDeCostos> Modificar(int id, CentroDeCostosCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
