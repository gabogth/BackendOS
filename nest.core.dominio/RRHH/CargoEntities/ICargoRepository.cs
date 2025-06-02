namespace nest.core.dominio.RRHH.CargoEntities
{
    public interface ICargoRepository
    {
        Task<Cargo> ObtenerPorId(int id);
        Task<List<Cargo>> ObtenerTodos();
        Task<List<Cargo>> ObtenerActivos();
        Task<Cargo> Agregar(CargoCrearDto entidad);
        Task<Cargo> Modificar(int id, CargoCrearDto entidad);
        Task Eliminar(int id);
    }
}
