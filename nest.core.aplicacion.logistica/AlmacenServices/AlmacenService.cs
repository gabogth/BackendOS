using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.AlmacenServices
{
    public class AlmacenService
    {
        private readonly IAlmacenRepository repository;
        public AlmacenService(IAlmacenRepository repository)
        {
            this.repository = repository;
        }

        public Task<Almacen> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<Almacen>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<Almacen>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<Almacen> Agregar(AlmacenCrearDto entry) => repository.Agregar(entry);
        public Task<Almacen> Modificar(int id, AlmacenCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
