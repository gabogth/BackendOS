using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajoServices
{
    public class RegistroAsistenciaOrdenTrabajoService
    {
        private readonly IRegistroAsistenciaOrdenTrabajoRepository repository;

        public RegistroAsistenciaOrdenTrabajoService(IRegistroAsistenciaOrdenTrabajoRepository repository)
        {
            this.repository = repository;
        }

        public Task<RegistroAsistenciaOrdenTrabajo> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<RegistroAsistenciaOrdenTrabajo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<RegistroAsistenciaOrdenTrabajo> Agregar(RegistroAsistenciaOrdenTrabajoCrearDto entry) => repository.Agregar(entry);
        public Task<RegistroAsistenciaOrdenTrabajo> Modificar(long id, RegistroAsistenciaOrdenTrabajoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
