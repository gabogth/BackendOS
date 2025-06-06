using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh
{
    public class PersonalService
    {
        private readonly IPersonalRepository repository;
        public PersonalService(IPersonalRepository repository)
        {
            this.repository = repository;
        }
        public Task<Personal> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<Personal>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<Personal>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<Personal> Agregar(PersonalCrearDto entry) => repository.Agregar(entry);
        public Task<Personal> Modificar(int id, PersonalCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
