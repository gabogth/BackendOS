using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica
{
    public class AlmacenService
    {
        private readonly IAlmacenRepository repository;
        public AlmacenService(IAlmacenRepository repository)
        {
            this.repository = repository;
        }

        public Task<Almacen> ObtenerPorId(int id) => this.repository.ObtenerPorId(id);
        public Task<List<Almacen>> ObtenerTodos() => this.repository.ObtenerTodos();
        public Task<List<Almacen>> ObtenerActivos() => this.repository.ObtenerActivos();
        public Task<Almacen> Agregar(AlmacenCrearDto entry) => this.repository.Agregar(entry);
        public Task<Almacen> Modificar(int id, AlmacenCrearDto entry) => this.repository.Modificar(id, entry);
        public Task Eliminar(int id) => this.repository.Eliminar(id);
    }
}
