using nest.core.dominio.Finanzas.MonedaEntities;

namespace nest.core.aplicacion.finanzas.MonedaServices
{
    public class MonedaService
    {
        private readonly IMonedaRepository repository;
        public MonedaService(IMonedaRepository repository)
        {
            this.repository = repository;
        }
        public Task<Moneda> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<Moneda>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<Moneda> Agregar(MonedaCrearDto entry) => repository.Agregar(entry);
        public Task<Moneda> Modificar(int id, MonedaCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
