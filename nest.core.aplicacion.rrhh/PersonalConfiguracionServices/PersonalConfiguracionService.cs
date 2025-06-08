using nest.core.dominio.RRHH.PersonalConfiguracionEntities;

namespace nest.core.aplicacion.rrhh.PersonalConfiguracionServices
{
    public class PersonalConfiguracionService
    {
        private readonly IPersonalConfiguracionRepository repository;
        public PersonalConfiguracionService(IPersonalConfiguracionRepository repository)
        {
            this.repository = repository;
        }
        public Task<PersonalConfiguracion> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<PersonalConfiguracion>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<PersonalConfiguracion>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<PersonalConfiguracion> Agregar(PersonalConfiguracionCrearDto entry) => repository.Agregar(entry);
        public Task<PersonalConfiguracion> Modificar(int id, PersonalConfiguracionCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
