using nest.core.dominio.Mantto.LaborEntities;

namespace nest.core.aplicacion.mantto.LaborServices
{
    public class LaborService
    {
        private readonly ILaborRepository repository;
        public LaborService(ILaborRepository repository)
        {
            this.repository = repository;
        }

        public Task<Labor> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<Labor>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<Labor>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<Labor> Agregar(LaborCrearDto entry) => repository.Agregar(entry);
        public Task<Labor> Modificar(int id, LaborCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
