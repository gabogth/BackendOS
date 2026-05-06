using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.General.DistritoEntities
{
    public interface IDistritoRepository
    {
        Task<Distrito> ObtenerPorId(int id);
        Task<List<Distrito>> ObtenerTodos();
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<Distrito> Agregar(Distrito entry);
        Task<Distrito> Modificar(Distrito entry);
        Task Eliminar(int id);
    }
}
