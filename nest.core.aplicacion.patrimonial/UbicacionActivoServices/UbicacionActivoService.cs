using nest.core.dominio.Patrimonial.UbicacionActivoEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionActivoServices
{
    public class UbicacionActivoService
    {
        private readonly IUbicacionActivoRepository repository;

        public UbicacionActivoService(IUbicacionActivoRepository repository)
        {
            this.repository = repository;
        }

        public Task<UbicacionActivo> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<UbicacionActivo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<UbicacionActivo>> ObtenerPorActivo(long activoId) => repository.ObtenerPorActivo(activoId);
        public Task<UbicacionActivo> Agregar(UbicacionActivoCrearDto entry) => repository.Agregar(entry);
        public Task<UbicacionActivo> Modificar(long id, UbicacionActivoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
