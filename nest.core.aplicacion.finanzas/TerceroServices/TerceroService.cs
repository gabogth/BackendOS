using nest.core.dominio.Finanzas.ClienteEntities;

namespace nest.core.aplicacion.finanzas.TerceroServices
{
    public class TerceroService
    {
        private readonly ITerceroRepository repository;
        public TerceroService(ITerceroRepository repository)
        {
            this.repository = repository;
        }
        public Task<Tercero> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<Tercero>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<Tercero> Agregar(TerceroCrearDto entry) => repository.Agregar(entry);
        public Task<Tercero> Modificar(int id, TerceroCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
