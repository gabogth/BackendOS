using nest.core.dominio.Mantto.MantenimientoTipoEntities;

namespace nest.core.aplicacion.mantto.MantenimientoTipoServices
{
    public class MantenimientoTipoService
    {
        private readonly IMantenimientoTipoRepository repository;
        public MantenimientoTipoService(IMantenimientoTipoRepository repository)
        {
            this.repository = repository;
        }

        public Task<MantenimientoTipo> ObtenerPorId(short id) => repository.ObtenerPorId(id);
        public Task<List<MantenimientoTipo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<MantenimientoTipo>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<MantenimientoTipo> Agregar(MantenimientoTipoCrearDto entry) => repository.Agregar(entry);
        public Task<MantenimientoTipo> Modificar(short id, MantenimientoTipoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(short id) => repository.Eliminar(id);
    }
}
