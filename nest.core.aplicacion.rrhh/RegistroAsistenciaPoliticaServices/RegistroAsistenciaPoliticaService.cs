using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticaServices
{
    public class RegistroAsistenciaPoliticaService
    {
        private readonly IRegistroAsistenciaPoliticaRepository repository;
        public RegistroAsistenciaPoliticaService(IRegistroAsistenciaPoliticaRepository repository)
        {
            this.repository = repository;
        }

        public Task<RegistroAsistenciaPolitica> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<RegistroAsistenciaPolitica>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<RegistroAsistenciaPolitica> Agregar(RegistroAsistenciaPoliticaCrearDto entry) => repository.Agregar(entry);
        public Task<RegistroAsistenciaPolitica> Modificar(long id, RegistroAsistenciaPoliticaCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
