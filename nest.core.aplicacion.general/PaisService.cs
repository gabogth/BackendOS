using nest.core.dominio.General.PaisEntities;

namespace nest.core.aplicacion.general
{
    public class PaisService
    {
        private readonly IPaisRepository repository;
        public PaisService(IPaisRepository repository)
        {
            this.repository = repository;
        }
        public Task<Pais> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<Pais>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<Pais>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<Pais> Agregar(PaisCrearDto entry) => repository.Agregar(entry);
        public Task<Pais> Modificar(int id, PaisCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
