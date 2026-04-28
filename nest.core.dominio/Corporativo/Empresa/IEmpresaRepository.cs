using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.Corporativo.Empresa
{
    public interface IEmpresaRepository
    {
        Task<List<Empresa>> ObtenerTodos();
        Task<List<Empresa>> ObtenerActivos();
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<Empresa?> ObtenerPorId(int id);
        Task<Empresa> Agregar(Empresa entidad);
        Task<Empresa> Modificar(Empresa entidad);
        Task Eliminar(int id);
    }
}
