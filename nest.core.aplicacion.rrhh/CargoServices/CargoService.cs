using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.CargoServices
{
    public class CargoService
    {
        private readonly ICargoRepository repository;
        public CargoService(ICargoRepository repository)
        {
            this.repository = repository;
        }

        public Task<Cargo> ObtenerPorId(int id) => this.repository.ObtenerPorId(id);
        public Task<List<Cargo>> ObtenerTodos() => this.repository.ObtenerTodos();
        public Task<List<Cargo>> ObtenerActivos() => this.repository.ObtenerActivos();
        public Task<Cargo> Agregar(CargoCrearDto entry) => this.repository.Agregar(entry);
        public Task<Cargo> Modificar(int id, CargoCrearDto entry) => this.repository.Modificar(id, entry);
        public Task Eliminar(int id) => this.repository.Eliminar(id);
    }
}
