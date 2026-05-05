using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.Logistica.AlmacenEN
{
    public interface IAlmacenRepository
    {
        Task<Almacen> ObtenerPorId(int id);
        Task<List<Almacen>> ObtenerTodos();
        Task<List<Almacen>> ObtenerActivos();
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<Almacen> Agregar(Almacen entry);
        Task<Almacen> Modificar(Almacen entry);
        Task Eliminar(int id);
    }
}
