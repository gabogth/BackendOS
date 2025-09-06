using nest.core.dominio.RRHH.GrupoHorarioEntities;

namespace nest.core.aplicacion.rrhh.GrupoHorarioServices
{
    public class GrupoHorarioService
    {
        private readonly IGrupoHorarioRepository repository;
        public GrupoHorarioService(IGrupoHorarioRepository repository)
        {
            this.repository = repository;
        }

        public Task<GrupoHorario> ObtenerPorId(int id) => this.repository.ObtenerPorId(id);
        public Task<List<GrupoHorario>> ObtenerTodos() => this.repository.ObtenerTodos();
        public Task<List<GrupoHorario>> ObtenerActivos() => this.repository.ObtenerActivos();
        public Task<GrupoHorario> Agregar(GrupoHorarioCrearDto entry) => this.repository.Agregar(entry);
        public Task<GrupoHorario> Modificar(int id, GrupoHorarioCrearDto entry) => this.repository.Modificar(id, entry);
        public Task Eliminar(int id) => this.repository.Eliminar(id);
    }
}
