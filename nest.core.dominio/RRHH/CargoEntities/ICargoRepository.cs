using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

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
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
    }
}
