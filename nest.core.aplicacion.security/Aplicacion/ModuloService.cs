using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Aplicacion.Modulo.Repository;

namespace nest.core.aplicacion.security.Aplicacion
{
    public class ModuloService
    {
        private readonly IModuloRepository repository;
        public ModuloService(IModuloRepository repository) 
        { 
            this.repository = repository;
        }

        public Task<Modulo> ObtenerPorId(int id) => this.repository.ObtenerPorId(id);
        public Task<List<Modulo>> ObtenerTodos() => this.repository.ObtenerTodos();
        public Task<List<Modulo>> ObtenerPorUnaPropiedad(Dictionary<string, object> filtros) => this.repository.ObtenerPorUnaPropiedad(filtros);
        public Task<Modulo> Agregar(ModuloCrearDto entry) => this.repository.Agregar(entry);
        public Task<Modulo> Modificar(int id, ModuloCrearDto entry) => this.repository.Modificar(id, entry);
        public Task Eliminar(int id) => this.Eliminar(id);
    }
}
