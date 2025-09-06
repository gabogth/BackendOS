using nest.core.dominio.RRHH.HorarioCabeceraEntities;

namespace nest.core.aplicacion.rrhh.HorarioServices
{
    public class HorarioService
    {
        private readonly IHorarioRepository repository;
        public HorarioService(IHorarioRepository repository)
        {
            this.repository = repository;
        }

        public Task<HorarioCabecera> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<HorarioCabecera>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<HorarioCabecera> Agregar(HorarioDto entry) => repository.Agregar(entry);
        public Task<HorarioCabecera> Modificar(int id, HorarioDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
