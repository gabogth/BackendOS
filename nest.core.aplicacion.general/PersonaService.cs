using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general
{
    public class PersonaService
    {
        private readonly IPersonaRepository repository;
        public PersonaService(IPersonaRepository repository)
        {
            this.repository = repository;
        }

        public Task<Persona> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<Persona>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<Persona>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<Persona> Agregar(PersonaCrearDto entry) => repository.Agregar(entry);
        public Task<Persona> Modificar(int id, PersonaCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
