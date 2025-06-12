using nest.core.dominio.General.DistritoEntities;

namespace nest.core.aplicacion.general.DistritoServices
{
    public class DistritoService
    {
        private readonly IDistritoRepository repository;
        public DistritoService(IDistritoRepository repository)
        {
            this.repository = repository;
        }
        public Task<Distrito> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<Distrito>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<Distrito> Agregar(DistritoCrearDto entry) => repository.Agregar(entry);
        public Task<Distrito> Modificar(int id, DistritoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
