using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.aplicacion.rrhh.PersonalEstadoServices
{
    public class PersonalEstadoService
    {
        private readonly IPersonalEstadoRepository repository;
        public PersonalEstadoService(IPersonalEstadoRepository repository)
        {
            this.repository = repository;
        }
        public Task<PersonalEstado> ObtenerPorId(byte id) => repository.ObtenerPorId(id);
        public Task<List<PersonalEstado>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<PersonalEstado>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<PersonalEstado> Agregar(PersonalEstadoCrearDto entry) => repository.Agregar(entry);
        public Task<PersonalEstado> Modificar(byte id, PersonalEstadoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(byte id) => repository.Eliminar(id);
    }
}
