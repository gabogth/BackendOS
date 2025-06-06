using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.aplicacion.general
{
    public class ProvinciaService
    {
        private readonly IProvinciaRepository repository;
        public ProvinciaService(IProvinciaRepository repository)
        {
            this.repository = repository;
        }
        public Task<Provincia> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<Provincia>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<Provincia>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<Provincia> Agregar(ProvinciaCrearDto entry) => repository.Agregar(entry);
        public Task<Provincia> Modificar(int id, ProvinciaCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
