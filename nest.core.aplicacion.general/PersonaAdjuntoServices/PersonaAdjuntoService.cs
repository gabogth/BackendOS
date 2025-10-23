using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.PersonaAdjuntoServices
{
    public class PersonaAdjuntoService
    {
        private readonly IPersonaAdjuntoRepository repository;
        public PersonaAdjuntoService(IPersonaAdjuntoRepository repository)
        {
            this.repository = repository;
        }

        public Task<PersonaAdjunto> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<PersonaAdjunto>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<PersonaAdjunto>> ObtenerPorPersona(int personaId) => repository.ObtenerPorPersona(personaId);
        public Task<PersonaAdjunto> Agregar(PersonaAdjuntoCrearDto entry) => repository.Agregar(entry);
        public Task<PersonaAdjunto> Modificar(long id, PersonaAdjuntoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
