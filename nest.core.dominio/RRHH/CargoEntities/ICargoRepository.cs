namespace nest.core.dominio.RRHH.CargoEntities
{
    public interface ICargoRepository
    {
        Task<Cargo> ObtenerPorId(int id);
        Task<List<Cargo>> ObtenerTodos();
        Task<List<Cargo>> ObtenerActivos();
        Task<Cargo> Agregar(Cargo entidad);
        Task<Cargo> Modificar(Cargo entidad);
        Task Eliminar(int id);
    }
}
