using nest.core.dominio.Patrimonial.ActivoEntities;

namespace nest.core.aplicacion.patrimonial.ActivoServices
{
    public class ActivoService
    {
        private readonly IActivoRepository repository;
        public ActivoService(IActivoRepository repository)
        {
            this.repository = repository;
        }

        public Task<Activo> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<Activo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<Activo>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<Activo> Agregar(ActivoCrearDto entry) => repository.Agregar(entry);
        public Task<Activo> Modificar(long id, ActivoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
