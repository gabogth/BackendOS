using nest.core.dominio.Finanzas.PuntoFinancieroEntities;

namespace nest.core.aplicacion.finanzas.PuntoFinancieroServices
{
    public class PuntoFinancieroService
    {
        private readonly IPuntoFinancieroRepository repository;
        public PuntoFinancieroService(IPuntoFinancieroRepository repository)
        {
            this.repository = repository;
        }
        public Task<PuntoFinanciero> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<PuntoFinanciero>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<PuntoFinanciero>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<PuntoFinanciero> Agregar(PuntoFinancieroCrearDto entry) => repository.Agregar(entry);
        public Task<PuntoFinanciero> Modificar(int id, PuntoFinancieroCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
