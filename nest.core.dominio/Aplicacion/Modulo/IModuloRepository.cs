using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.Aplicacion.Modulo.Repository
{
    public interface IModuloRepository
    {
        Task<Modulo> ObtenerPorId(int id);
        Task<List<Modulo>> ObtenerTodos();
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<List<Modulo>> ObtenerPorUnaPropiedad(Dictionary<string, object?> filtros);
        Task<Modulo> Agregar(Modulo entry);
        Task<Modulo> Modificar(Modulo entry);
        Task Eliminar(int id);
    }
}
